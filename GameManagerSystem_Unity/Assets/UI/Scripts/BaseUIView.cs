/************************************************************
* COPYRIGHT:  2026
* PROJECT: System Sandbox
* FILE NAME: BaseUIView.cs
* DESCRIPTION:
* Base class responsible for discovering UI Toolkit interactable
* elements (Buttons) and forwarding their events to higher-level controllers.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/27 | Akram Taghavi-Burris | Created class
* 2026/03/11 | Leyton McKinney | Add support for toggles and sliders.
*
*
************************************************************/


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public abstract class BaseUIView : MonoBehaviour
{
    // Reference to the UIDocument component attached to this GameObject.
    protected UIDocument _uiDocument;
    
    // The root VisualElement of the top-level container UI Document.
    private VisualElement _root;


    // INTERACTABLE MAPS
    //  Buttons -> Command Tokens
    protected Dictionary<Button, UICommandType?> _buttonMap = new();

    // Sliders -> Command Tokens
    protected Dictionary<Slider, UICommandType?> _sliderMap = new();

    // Toggles -> Command Tokens
    protected Dictionary<Toggle, UICommandType?> _toggleMap = new();


    // Awake is called once on initialization (before Start)
    protected virtual void Awake()
    {
        // Retrieve the UIDocument component attached to this GameObject.
        _uiDocument = GetComponent<UIDocument>();
        
        // Retrieve the root element of the UI hierarchy
        _root = _uiDocument.rootVisualElement;
        
        // Safety check in case the UI document was not properly assigned.
        if(_root == null)
        {
            Debug.LogError("No visual element root found, ensure UXML document is set.");
            return;
        }

    } //end Awake()

    // OnEnable is called every time the object becomes active.
    protected virtual void OnEnable()
    {

        BuildInteractableMap();
        RegisterInteractableCallbacks();
        
    } //end OnEnable()
    

    //OnDisable is called every time the object becomes inactive
    protected void OnDisable()
    {
        UnregisterInteractableCallbacks();
        
    }//end OnClickButton

    
    // Queries UI Interactable and maps references 
    private void BuildInteractableMap()
    {
        // Create a list of all ui interactable in the UXML hierarchy
        List<Button> buttons = _root.Query<Button>().ToList();
        List<Slider> sliders = _root.Query<Slider>().ToList();
        List<Toggle> toggles = _root.Query<Toggle>().ToList();

        
        // Debug warning if the UI contains no interactable elements.
       if (buttons.Count == 0 &&
           sliders.Count == 0 &&
           toggles.Count == 0)
       {
           Debug.LogWarning($"[BaseUIView] No interactable elements found in {_uiDocument.name}. " +
                            "Ignore this if this is a static overlay (e.g., HUD or Loading Screen).");
           return;
           
       }//end if interactable check

       foreach (var button in buttons)
       {
            UICommandType? token = UIMappingRegistry.TryGetCommand(button.name, out var cmd) ? cmd : null;
            _buttonMap[button] = token;
       }
       
       foreach (var slider in sliders)
       {
            UICommandType? token = UIMappingRegistry.TryGetCommand(slider.name, out var cmd) ? cmd : null;
            _sliderMap[slider] = token;
       }

       foreach (var toggle in toggles)
        {
            UICommandType? token = UIMappingRegistry.TryGetCommand(toggle.name, out var cmd) ? cmd : null;
            _toggleMap[toggle] = token;
        }

    }//end BuildIntractableMap()
    
    
    
    // Register the necessary UI Toolkit callbacks to each Interactable
    private void RegisterInteractableCallbacks()
    {
        // Register Button interactions (click & submit)
        foreach (var button in _buttonMap.Keys)
        {
            // UI Toolkit callbacks require an EventBase parameter so event data can be passed.
            
            // Register callback for when a button is clicked with a pointer device.
            button.RegisterCallback<ClickEvent>(HandleButtonTriggered);
            
            // Register callback for a (button) submit or confirm, when pressing Enter or gamepad submit.
            button.RegisterCallback<NavigationSubmitEvent>(HandleButtonTriggered);
            
        }//end foreach Button

        // Register slider interactions (on value changed)
        foreach (var slider in _sliderMap.Keys)
        {
            slider.RegisterCallback<ChangeEvent<float>>(HandleSliderChanged);
        }

        foreach (var toggle in _toggleMap.Keys)
        {
            toggle.RegisterCallback<ChangeEvent<bool>>(HandleToggleChanged);
        }
        
        
    }//end RegisterInteractableCallbacks()


    private void UnregisterInteractableCallbacks()
    {
        // Unregister all Button objects in the dictionary
        foreach (var button in _buttonMap.Keys)
        {
            button.UnregisterCallback<ClickEvent>(HandleButtonTriggered);
            button.UnregisterCallback<NavigationSubmitEvent>(HandleButtonTriggered);

        }//end foreach button

        foreach (var slider in _sliderMap.Keys)
        {
            slider.UnregisterCallback<ChangeEvent<float>>(HandleSliderChanged);
        }

        foreach (var toggle in _toggleMap.Keys)
        {
            toggle.UnregisterCallback<ChangeEvent<bool>>(HandleToggleChanged);
        }
        

    }//end UnregisterButtonCallbacks()
    
    
    // EVENT HANDLERS
    /// Handles button interactions, whether from a click or a submit/navigation event.
    private void HandleButtonTriggered(EventBase evt)
    {
        // Check if the event's target is a Button
        // and if that Button exists in our _buttonMap dictionary
        if (evt.target is Button button && _buttonMap.TryGetValue(button, out var action))
        {
            Debug.Log($"[BaseUIView] Button {button.name} has been triggered.");
            // Check if button action has a global command token
            if (action.HasValue)
            {
                // Forward the token to the controller via the abstract method.
                OnGlobalButtonClicked(action.Value);
            }
            else
            {
                // Button has not corresponding token
                // Forward to menu-specific handler, passing the button's UXML name.
                OnMenuSpecificButtonClicked(button.name);
            }
            
        }//end if(button)
        
    }//end HandleButtonTriggered()
    
    private void HandleSliderChanged(ChangeEvent<float> evt)
    {
        // Check if the event's target is a Slider
        // and if the Slider exists in the dictionary
        if (evt.target is Slider slider && _sliderMap.TryGetValue(slider, out var action))
        {
            Debug.Log($"[BaseUIView] Slider {slider.name} changed to {evt.newValue}.");

            if (action.HasValue)
            {
                OnGlobalSliderChanged(action.Value, evt.newValue);
            }
        }
    }

    private void HandleToggleChanged(ChangeEvent<bool> evt)
    {
        if (evt.target is Toggle toggle && _toggleMap.TryGetValue(toggle, out var action))
        {
            Debug.Log($"[BaseUIView] Toggle {toggle.name} changed to {evt.newValue}");

            if (action.HasValue)
            {
                OnGlobalToggleChanged(action.Value, evt.newValue);
            }
        }
    }
    


// --- MUST IMPLEMENT --- //

    /// <summary>
    /// Called when a button representing a global command is clicked.
    /// </summary>
    /// <param name="action">
    /// The command token representing the player's intent
    /// (e.g., StartGame, QuitGame, OpenSettings).
    /// </param>
    protected abstract void OnGlobalButtonClicked(UICommandType action);


    /// <summary>
    /// Called when a button exists only within a specific menu
    /// and does not map to a global command token.
    /// </summary>
    /// <param name="buttonName">
    /// The name of the button defined in the UXML layout.
    /// </param>
    protected abstract void OnMenuSpecificButtonClicked(string buttonName);

    /// <summary>
    /// Called when a slider representing a global setting is changed.
    /// </summary>
    /// <param name="action"></param>
    /// <param name="value"></param>
    protected abstract void OnGlobalSliderChanged(UICommandType action, float value);

    /// <summary>
    /// Called when a toggle representing a global setting is changed.
    /// </summary>
    /// <param name="action"></param>
    /// <param name="value"></param>
    protected abstract void OnGlobalToggleChanged(UICommandType action, bool value);


}//end BaseUIView
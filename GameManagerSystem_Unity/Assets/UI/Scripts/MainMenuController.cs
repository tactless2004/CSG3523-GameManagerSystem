/************************************************************
 * COPYRIGHT:  2026
 * PROJECT: Systems Sandbox
 * FILE NAME: MainMenuController.cs
 * DESCRIPTION: 
 * Controls the main menu UI behaviors. Inherits from BaseUIView
 *
 * REVISION HISTORY:
 * Date [YYYY/MM/DD] | Author | Comments
 * ------------------------------------------------------------
 * 2026/02/20 | Akram Taghavi-Burris | Created class
 * 2026/03/11 | Leyton McKinney | Add stubbed out Toggle and Slider "implementations".
 ************************************************************/
 
using UnityEngine;

/// <summary>
/// Controls the main menu UI behaviors. Inherits from <see cref="BaseUIView"/>
/// </summary>
public class MainMenuController : BaseUIView
{
    public GameObject OptionsMenu;
    private GameObject OptionsMenuInstance;
    
    // Start is called once before the first Update
    void Start()
    {
        // TEMPORARY: Initializes the UICommandHandler to set up event subscriptions.
        UICommandHandler.Initialize();
        OptionsMenuInstance = Instantiate(OptionsMenu);
        
    }//end Start()
    
    
    /// <summary>
    /// Handles global button clicks for the Main Menu, broadcasting events
    /// to the event bus (e.g., StartGame, QuitGame).
    /// </summary>
    /// <param name="action">The global action triggered by the user.</param>
    protected override void OnGlobalButtonClicked(UICommandType action)
    {
        
        // Invoke Events to Bus
        switch (action)
        {
            case UICommandType.StartGame:
                UIEvents.OnStartGameRequested?.Invoke(); // Shout into the bus!
                break;
            
            case UICommandType.QuitGame:
                UIEvents.OnQuitRequested?.Invoke();
                break;
            case UICommandType.ToggleMenu:
                UIEvents.OnOptionsToggle?.Invoke(OptionsMenuInstance);
                break;
            
        }//end Switch
        
    }//end OnGlobalButtonClicked()


    protected override void OnMenuSpecificButtonClicked(string buttonName)
    {
        switch(buttonName)
        {
            case "optionsButton":
                Debug.Log("Open Options Panel");
                OpenMenu();
                break;
            case "creditsButton":
                Debug.Log("Open Credits Panel");
                break;
        }
    }//end OnMenuSpecificButtonClicked

    /// <summary>
    /// Opens the specified menu by setting it active.
    /// </summary>
    /// <param name="menu">The GameObject representing the menu panel.</param>
    private void OpenMenu()
    {
        if (OptionsMenuInstance == null)
        {
            OptionsMenuInstance = Instantiate(OptionsMenu);
            OptionsMenuInstance.SetActive(true);
        }
        else
        {
            OptionsMenuInstance.SetActive(!OptionsMenuInstance.activeInHierarchy);
        }
        
    }//end OpenMenu()

    protected override void OnGlobalSliderChanged(UICommandType action, float value)
    {
        // MainMenu has no sliders, as such this is left intentionally empty.
        // Settings sliders are handled by OptionsMenuController.
    }

    protected override void OnGlobalToggleChanged(UICommandType action, bool value)
    {
        // MainMenu has no toggles, as such this is left intentionally empty.
        // Settings toggles are handled by OptionsMenuController.
    }

}//end MainMenuController
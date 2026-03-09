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
 *
 *
 ************************************************************/
 
using UnityEngine;

/// <summary>
/// Controls the main menu UI behaviors. Inherits from <see cref="BaseUIView"/>
/// </summary>
public class MainMenuController : BaseUIView
{
    /// <summary>
    /// TEMPORARY: Reference to the Options menu GameObject to toggle visibility.
    /// </summary>
    public GameObject OptionsMenu;
    
    
    // Start is called once before the first Update
    void Start()
    {
        // TEMPORARY: Initializes the UICommandHandler to set up event subscriptions.
        UICommandHandler.Initialize();
        
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
            
        }//end Switch
        
    }//end OnGlobalButtonClicked()


    protected override void OnMenuSpecificButtonClicked(string buttonName)
    {
        switch(buttonName)
        {
            case "optionsButton":
                Debug.Log("Open Options Panel");
                OpenMenu(OptionsMenu);
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
    private void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
        
    }//end OpenMenu()
    
    
    
}//end MainMenuController
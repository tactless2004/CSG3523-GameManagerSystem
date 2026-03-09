/************************************************************
 * COPYRIGHT:  2026
 * PROJECT: System Sandbox
 * FILE NAME: UICommands.cs
 * DESCRIPTION: Shared Logic for all UI Buttons
 *
 * REVISION HISTORY:
 * Date [YYYY/MM/DD] | Author | Comments
 * ------------------------------------------------------------
 * 2026/02/24 | Akram Taghavi-Burris | Created class
 *
 *
 ************************************************************/
 
 
using UnityEngine;

public static class UICommandHandler
{
    
    // Call this once (e.g., in a "Bootstrapper" or "GameManager" Awake)
    //Note because UICommands is not a MonoBehaviour it does not have an enable. 
    public static void Initialize()
    {
        // Unsubscribe first to ensure we only have ONE subscription
        UIEvents.OnStartGameRequested -= StartGame;
        UIEvents.OnQuitRequested -= QuitGame;
        
        UIEvents.OnStartGameRequested += StartGame;
        UIEvents.OnQuitRequested += QuitGame;
    }
    
    public static void StartGame()
    {
        Debug.Log("UI System: Requesting Game Start...");
        // Tell the Brain to change state
        //GameManager.Instance.ChangeState(GameState.Playing); 
        // Logic for loading the actual scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
        
    }//end StartGame()

    
    public static void QuitGame() 
    {
        Debug.Log("UI System: Quitting...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }//end QuitGame()

    
    public static void CloseMenu(GameObject menuObject)
    {
        // Maybe you use a specific event system or just deactivate
        menuObject.SetActive(false);
        
    }//end CloseMenu()
    
}//end UICommands
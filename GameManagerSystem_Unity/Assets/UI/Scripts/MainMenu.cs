/************************************************************
* COPYRIGHT:  2026
* PROJECT: Systems Sandbox
* FILE NAME: MainMenu.cs
* DESCRIPTION: Controls the main menu behaviors
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Akram Taghavi-Burris | Created class
*
*
************************************************************/
 

using UnityEngine;
using UnityEngine.UIElements;


public class MainMenu : MonoBehaviour
{
    [Header("Assign UIDocument GameObject")]
    public UIDocument UIDocument;

    private Button _playButton;
    
    // Awake is called once on initialization (before Start)
    private void Awake()
    {
        // Get the root VisualElement from the UIDocument
        VisualElement root = UIDocument.rootVisualElement;

        // Query the play button by its name (set in UXML)
        _playButton = root.Q<Button>("playButton");
        
        
    } //end Awake()
 
    private void OnEnable()
    {
        if (_playButton != null)
        {
            _playButton.clicked += OnPlayButtonClicked;
        }
        
    }

    private void OnDisable()
    {
        _playButton.clicked -= OnPlayButtonClicked;
    }
 

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked! Loading game...");
        
    }//end CustomMethod(int)

 
}//end MainMenuController
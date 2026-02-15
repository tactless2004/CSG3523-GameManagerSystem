/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment 
* FILE NAME: MainMenuState.cs
* DESCRIPTION: MainMenu IState implementation.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Leyton McKinney | Init 
*
*
************************************************************/
 
using UnityEngine;
 
public class MainMenuState : IState
{
  public string Name => "MainMenu";

  public void Enter() {
    Debug.Log($"Entering {Name} State");
  }

  public void Execute() {
    // Main menu logic tba
  }

  public void Exit() {
    Debug.Log($"Exitting {Name} State");
  }
}

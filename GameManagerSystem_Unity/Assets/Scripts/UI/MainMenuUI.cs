/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment 
* FILE NAME: MainMenuUI.cs
* DESCRIPTION: Functionality for interactable UI components in the MainMenu. 
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Leyton McKinney | Init
*
************************************************************/
 
using UnityEngine;
 
public class MainMenuUI : MonoBehaviour
{
  private GameManager _gm;

  private void Awake() {
    _gm = GameManager.Instance;  
  }

  public void PlayButton() {
    _gm.ReplaceStates(_gm.PlayState);
  }

  public void GameoverButton() {
    _gm.ReplaceStates(_gm.GameOverState);
  }
}

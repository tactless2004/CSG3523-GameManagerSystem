/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment 
* FILE NAME: GameOverState.cs
* DESCRIPTION: IState implementation for GameOverState. 
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/16 | Leyton McKinney | Init
*
************************************************************/
 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : BaseGameState 
{
  private const string GAMEOVER_SCENE = "Gameover";
  public string Name => "GameOver"; 

  public override void Enter() {
    Debug.Log($"Entered {Name} Scene");
    SceneManager.LoadScene(GAMEOVER_SCENE);
  }

  public override void Execute() {}
  public override void Exit()    {}
}

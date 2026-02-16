/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment  
* FILE NAME: PlayState.cs
* DESCRIPTION: IState implementation for PlayState.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2000/01/01 | Your Name | Created class
*
*
************************************************************/
 
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : BaseGameState 
{
  public override string Name => "Playing";

  public override void Enter() {
    Debug.Log($"Entered {Name} Scene");
    SceneManager.LoadScene("Playing");
  }

  public override void Exit() {
  }

  public override void Execute() {
    if(Input.GetKeyDown(KeyCode.P)) {
        _gm.PushState(
          _gm.PauseState
        );
    }
  }

}

/************************************************************
* COPYRIGHT: 2026  
* PROJECT: CSG3523 - GameManagerSystem Assignment 
* FILE NAME: BootState.cs
* DESCRIPTION: IState implementation for initial game start.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/16 | Leyton McKinney | Init
*
*
************************************************************/
 
using UnityEngine;
 
public class BootState : BaseGameState 
{
  public override string Name {get; protected set; } = "Boot";

  public override void Enter() {
    Debug.Log($"Entering {Name} State");
  }

  public override void Execute() {
    _gm.ReplaceStates(_gm.MainMenuState);
  }

  public override void Exit() {
    Debug.Log($"Exitting {Name} State");
  }
}

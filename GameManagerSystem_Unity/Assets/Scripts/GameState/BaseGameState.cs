/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment 
* FILE NAME: BaseGameState.cs
* DESCRIPTION: 
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Leyton McKinney | Init
*
************************************************************/
 
using UnityEngine;
 
public class BaseGameState : IState 
{
  protected GameManager _gm;

  protected BaseGameState() {
    _gm = GameManager.Instance;
  }

  public virtual string Name { get; protected set; } = "Base Game State";

  // "Concrete" IState implementation
  public virtual void Enter()   {}
  public virtual void Exit()    {}
  public virtual void Execute() {}
}

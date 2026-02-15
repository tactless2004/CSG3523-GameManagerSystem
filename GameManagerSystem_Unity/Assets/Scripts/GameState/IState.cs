/***********************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment
* FILE NAME: IState.cs
* DESCRIPTION: Common interface for GameStates.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Leyton McKinney | Init
*
*
************************************************************/
 
using UnityEngine;
 
public interface IState
{
  void Enter();
  void Exit();
  void Execute(); 
}

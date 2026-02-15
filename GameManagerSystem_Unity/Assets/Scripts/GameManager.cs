/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment 
* FILE NAME: GameManager.cs
* DESCRIPTION: Main GameManager responsible for GameState storage and transition.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Leyton McKinney | Init
*
************************************************************/

using System.Collections.Generic;
using UnityEngine;
 
public class GameManager : Singleton<GameManager> {
  public IState CurrentState => _stateStack.Count > 0 ? _stateStack.Peek() : null;

  private Stack<IState> _stateStack = new();

  /// <summary>
  /// Adds a new state to the top of the state stack and makes it the active state.
  /// This automatically calls Enter() on the new state.
  /// </summary>
  /// <param name="newState">The new state to activate. </param>
  public void PushState(IState newState) {
    // 1.) Push state to stack
    _stateStack.Push(newState);

    // 2.) Enter the new state
    newState.Enter();

    // 3.) verify that the state change occurred properly
    ValidateStateChange();
  }

  /// <summary>
  /// Removes the current state from the stack.
  /// This automatically calls Exit() on the state being removed.
  /// </summary>
  public void PopState() {
    // First we check if the stack is non-empty
    if (CurrentState != null) {
      // Tell the state to exit, then remove it from our stack DS
      CurrentState.Exit();
      _stateStack.Pop();
    }
  }

  /// <summary>
  /// Clears all states from the stack and replaces them with a new state.
  /// This is useful when switching to exclusive game states.
  /// </summary>
  /// <param name="newState">The state the should become the only active state </param>
  public void ReplaceStates(IState newState) {
    while (_stateStack.Count > 0) {
      PopState();
    }

    PushState(newState);
  }

  private void ValidateStateChange() {
    Debug.Log("State Change validated!");
  }

  // Unity Object Lifetime Methods
  
  // There's literally no point in this btw
  // we're just overriding the base class' Awake method
  // just to call it and do nothing else.
  protected override void Awake() {
    base.Awake();
  }

  private void Update() {
    CurrentState?.Execute();
  }
}

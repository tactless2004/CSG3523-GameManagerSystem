/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment
* FILE NAME: PauseState.cs
* DESCRIPTION: IState implementation for PauseState.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Leyton McKinney | Init
*
************************************************************/
 
using UnityEngine;
 
public class PauseState : IState 
{
  public string Name => "Pause";

  private GameObject pauseCanvasPrefab;
  private GameObject pauseCanvasInstance;

  public void Enter() {
    Debug.Log($"Entering {Name} State");
    // The game manager holds the paused variable,
    // but the PauseState controls it.
 
    pauseCanvasPrefab = Resources.Load<GameObject>("Prefabs/PauseMenu");
    if (pauseCanvasPrefab != null) {
      pauseCanvasInstance = GameObject.Instantiate(pauseCanvasPrefab);
    } else {
      Debug.LogError("Tried to open pause menu, but the pause menu prefab did not exist");
    }

    Time.timeScale = 0.0f;
  }

  public void Execute() {
    if (Input.GetKeyDown(KeyCode.P)) {
      GameManager.Instance.PopState();
    }
  }

  public void Exit() {
    Debug.Log($"Exitting {Name} State");

    if (pauseCanvasInstance != null) {
      GameObject.Destroy(pauseCanvasInstance);
    }

    Time.timeScale = 1.0f;
  }

}

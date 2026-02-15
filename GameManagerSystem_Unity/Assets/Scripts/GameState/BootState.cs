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
using UnityEngine.SceneManagement;

public class BootState : BaseGameState 
{
  public override string Name {get; protected set; } = "Boot";

  private GameObject _loadingPrefab;
  private GameObject _prefabInstance;

  private const string LOADING_PREFAB_PATH = "Prefabs/LoadingCube";
  private const float MIN_DISPLAY_TIME = 2.0f;
  private const string MENU_SCENE_NAME = "MainMenu";
  private AsyncOperation _loadingOperation;
  private float _elapsedTime = 0.0f;

  public override void Enter() {
    Debug.Log($"Entering {Name} State");

    // Play load animation
    SpawnLoadingPrefab();

    // Start loading main menu scene in the bg
    // NOTE: I am intentionally not using LoadSceneMode.Additive,
    // this is an intentional decision not an oversight.
    // Otherwise, I have to explicitly unload the boot scene.
    // I acknowledge that this violates SRP, but it is the cleanest solution.
    _loadingOperation = SceneManager.LoadSceneAsync(MENU_SCENE_NAME);
    _loadingOperation.allowSceneActivation = false;
  }

  public override void Execute() {
    _elapsedTime += Time.deltaTime;

    // Verify:
    // 1.) The loading operation is not null => Some scene is getting loaded
    // 2.) That scene load is >= 90%
    // 3.) That the minimum elapsed time for scene load has occurred.
    if (
        _loadingOperation != null &&
        _loadingOperation.progress >= 0.9f &&
        _elapsedTime >= MIN_DISPLAY_TIME
    ) {
      _gm.ReplaceStates(_gm.MainMenuState);
    }
  }

  public override void Exit() {
    Debug.Log($"Exitting {Name} State");
    
    // Remove the loading prefab (should it exist) and then
    // allow the MainMenuScene to be loaded.
    if (_prefabInstance != null) GameObject.Destroy(_prefabInstance);
    if (_loadingOperation != null) _loadingOperation.allowSceneActivation = true;
  }

  private void SpawnLoadingPrefab() {
    // Try to grab the loading prefab resource
    // if the prefab is not null, we Instantiate it.
    // if the prefab is null, log warning and spawn a cube.
    _loadingPrefab = Resources.Load<GameObject>(LOADING_PREFAB_PATH);

    if (_loadingPrefab != null)
    {
      _prefabInstance = GameObject.Instantiate(_loadingPrefab);
    } else {
      Debug.LogWarning("LoadingCube prefab missing. Spawning a placeholder instead.");

      _prefabInstance = GameObject.CreatePrimitive(PrimitiveType.Cube);
      _prefabInstance.transform.position = Vector3.zero;
    }
  }
}

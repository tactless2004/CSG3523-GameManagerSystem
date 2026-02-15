/************************************************************
* COPYRIGHT: 2026 
* PROJECT: CSG3523 - GameManagerSystem Assignment 
* FILE NAME: Singleton.cs
* DESCRIPTION: Abstract Base Class for Singleton type objects. 
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/02/15 | Leyton McKinney | Init
*
*
************************************************************/
 
using UnityEngine;
 
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance {get; private set; }

    [SerializeField, Tooltip("Is the game object persistent through scenes")]
    private bool _isPersistent = true;

    private void ValidateInstance() {
        // To ensure Singleton singularity, we always take the first Instance
        // subsequent instantiations will first check if there already exists an instance
        // and if so Destroys the new instance at the beginning of its lifecycle.
        if (Instance == null) {
            Instance = this as T;
        }
        else {
            Destroy(gameObject);
        }
    }
    
    private void MakePersistent() {
        // Detatch the object from its parent (should it exist),
        // so, we don't set objects to not DestroyOnLoad by accident
        if (transform.parent != null) {
            transform.SetParent(null);
        }

        DontDestroyOnLoad(gameObject);
    }

    protected virtual void Awake() {
        ValidateInstance();
 
        if (_isPersistent) {
            MakePersistent();
        }
    }
}

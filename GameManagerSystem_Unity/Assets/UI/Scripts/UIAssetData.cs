/************************************************************
* COPYRIGHT:  2026
* PROJECT: CSG3523 - UI Project
* FILE NAME: UIAssetData.cs
* DESCRIPTION: Unity Editor UIAsset Object definition.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/03/10 | Leyton McKinney | Init
************************************************************/
 
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "UI / UIAsset")]
public class UIAssetData : ScriptableObject
{
    [Header("UI Asset Metadata")]
    [Tooltip("Auto-genreated string ID used by the UI registry. Do not edit manually")]
    public string ID;
    public GameObject prefab;

    [Tooltip("Does the UI cache on close for fast reload?")]
    public bool cacheOnClose = true;

    #if UNITY_EDITOR
    private void onValidate() {
        string fileName = this.name;
        string baseName = fileName.Replace("UI_", "").Replace("_Data", "");

        string snakeCaseID = System.Text.RegularExpressions.Regex.Replace(baseName, "([a-z])([A-Z])", "$1_$2").ToLower();

        // only if the ID is not snake case, update it.
        if (ID != snakeCaseID) {
            ID = snakeCaseID;
            UnityEditor.EditorUtility.SetDirty(this);
        }
    }
    #endif
}

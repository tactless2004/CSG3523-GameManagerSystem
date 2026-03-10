/************************************************************
* COPYRIGHT:  2026
* PROJECT: CSG3523 - UI Project
* FILE NAME: UIAssetRegistry.cs
* DESCRIPTION: Registry for UI Assets.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/03/10 | Leyton McKinney | Init
************************************************************/
 
using UnityEngine;
using System.Collections.Generic;

public class UIAssetRegistry : ScriptableObject
{
    [Header("All UI Assets")]
    [SerializeField] private List<UIAssetData> _uiAssets;

    // Dictionary that associates Asset IDs with their associated UIAssetData
    private Dictionary<string, UIAssetData> _uiAssetMap;

    public void Initialize()
    {
        _uiAssetMap = new Dictionary<string, UIAssetData>();
        foreach (var asset in _uiAssets)
        {
            if (!_uiAssetMap.ContainsKey(asset.ID))
            {
                _uiAssetMap.Add(asset.ID, asset);
            }
        }
    }

    /// <summary>
    /// Tries to get a UI Asset from an ID, returns null if not found.
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public UIAssetData Get(string ID)
    {
        _uiAssetMap.TryGetValue(ID, out var asset);
        return asset;
    }

    public List<UIAssetData> GetAll()
    {
        return _uiAssets;
    }

    public Dictionary<string, UIAssetData> GetDictionary()
    {
        return _uiAssetMap;
    }
}

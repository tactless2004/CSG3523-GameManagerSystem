/************************************************************
* COPYRIGHT:  Year
* PROJECT: Name of Project or Assignment
* FILE NAME: AudioManager.cs
* DESCRIPTION:
* Singleton manager responsible for handling audio settings.
* Subscribes to UIEvents and applies changeds to Unity's AudioListener.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/03/11 | Leyton McKinney | Init
*
************************************************************/
 
using UnityEngine;

/// <summary>
/// Singleton manager that listens to audio-related UI events
/// and applies them to Unity's global <see cref="AudioListener"/>
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [Header("Default Audio Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float _defaultMasterVolume = 1f;

    [SerializeField] private bool _defaultMuteAll = false;

    protected override void Awake()
    {
        base.Awake();

        if (Instance != this) return;

        ApplyDefaultSettings();
    }

    private void OnEnable()
    {
        UIEvents.OnMasterVolumeChanged += SetMasterVolume;
        UIEvents.OnMuteAllChanged += SetMuteAll;
    }
    private void OnDisable()
    {
        UIEvents.OnMasterVolumeChanged -= SetMasterVolume;
        UIEvents.OnMuteAllChanged -= SetMuteAll;
    }

    private void ApplyDefaultSettings()
    {
        SetMasterVolume(_defaultMasterVolume);
        SetMuteAll(_defaultMuteAll);
    }

    private void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        Debug.Log($"[AudioManager] Master volume set to {value}.");
    }

    private void SetMuteAll(bool isMuted)
    {
        AudioListener.pause = isMuted;
        Debug.Log($"[AudioManager] Mute all set to {isMuted}.");
    }
}

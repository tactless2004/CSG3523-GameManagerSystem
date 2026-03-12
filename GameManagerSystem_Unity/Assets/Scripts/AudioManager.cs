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

    [Header("Runtime Audio Settings")]
    [SerializeField] private bool _muted;
    [SerializeField] private float _masterVolume;

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
        SetMasterVolume(50); // work around
        SetMuteAll(_defaultMuteAll);
    }

    private void SetMasterVolume(float value)
    {
        // cache value even if muted.
        _masterVolume = value/100; // divide by 100 because because dom(slider) = [0, 100], dom(volume) = [0, 1]
        if (_muted) return;

        AudioListener.volume = _masterVolume;
        Debug.Log($"[AudioManager] Master volume set to {value}.");
    }

    private void SetMuteAll(bool isMuted)
    {
        AudioListener.volume = isMuted ? 0 : _masterVolume;
        _muted = isMuted;
        Debug.Log($"[AudioManager] Mute all set to {isMuted}.");
    }
}

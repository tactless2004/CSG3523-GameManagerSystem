/************************************************************
* COPYRIGHT:  Year
* PROJECT: Name of Project or Assignment
* FILE NAME: OptionsMenuController.cs
* DESCRIPTION:
* Controls the Options Menu UI behaviors. Inherits from BaseUIView.
* Handles audio setting inputs (sliders and toggles) and forwards
* their values to the event bus for AudioManager to consume.
*                   
* REVISION HISTORY:
* Date [YYYY/MM/DD] | Author | Comments
* ------------------------------------------------------------
* 2026/03/11 | Leyton McKinney | Init
*
************************************************************/
 
using UnityEngine;

public class OptionsMenuController : BaseUIView
{
    protected override void Awake()
    {
        // Explicitly grab the UI document
        base.Awake();
    }

    protected override void OnGlobalButtonClicked(UICommandType action)
    {
        switch (action)
        {
            case UICommandType.ToggleMenu:
                UIEvents.OnOptionsToggle(gameObject);
                break;
        }
    }

    protected override void OnMenuSpecificButtonClicked(string buttonName)
    {
        Debug.LogWarning($"[OptionsMenuController] Unhandled menu-specific button: {buttonName}");
    }

    protected override void OnGlobalSliderChanged(UICommandType action, float value)
    {
        switch (action)
        {
            case UICommandType.MasterVolume:
                UIEvents.OnMasterVolumeChanged?.Invoke(value);
                break;
        }
    }
    protected override void OnGlobalToggleChanged(UICommandType action, bool value)
    {
        switch (action)
        {
            case UICommandType.MuteAll:
                UIEvents.OnMuteAllChanged?.Invoke(value);
                break;
        }
    }
}

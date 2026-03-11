/************************************************************
 * COPYRIGHT:  2026
 * PROJECT: System Sandbox
 * FILE NAME: UIEvents.cs
 * DESCRIPTION: Shared Logic for all UI Buttons
 * Centralized static class for UI events.
 * Acts as a simple "event bus" or intercom for global UI signals.
 *
 * REVISION HISTORY:
 * Date [YYYY/MM/DD] | Author | Comments
 * ------------------------------------------------------------
 * 2026/02/24 | Akram Taghavi-Burris | Created class
 *
 *
 ************************************************************/

using System;
using UnityEngine;

public static class UIEvents
{
    // High-level signals (The "Intercom" channels)
    public static Action OnStartGameRequested;
    public static Action OnQuitRequested;
    public static Action<float> OnMasterVolumeChanged;
    public static Action<bool> OnMuteAllChanged;
    
}//end UIEvents
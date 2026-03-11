/************************************************************
 * COPYRIGHT:  2026
 * PROJECT: System Sandbox
 * FILE NAME: UIButtonActionMap.cs
 * DESCRIPTION:
 * Defines the standardized command tokens used by the UI system.
 * Each entry in this enum represents a possible player intent.
 *
 * REVISION HISTORY:
 * Date [YYYY/MM/DD] | Author | Comments
 * ------------------------------------------------------------
 * 2026/02/28 | Akram Taghavi-Burris | Created class
 *
 *
 ************************************************************/


/// <summary>
/// Represents the different command tokens that can be triggered by UI interactions.
/// These tokens are used by the Command Pattern to standardize player intent across the UI system.
/// </summary>
public enum UICommandType
{
    None,
    StartGame,
    QuitGame,
    ToggleMenu,
    MasterVolume,
    MuteAll,
}



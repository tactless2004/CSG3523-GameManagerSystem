/************************************************************
 * COPYRIGHT:  2026
 * PROJECT: System Sandbox
 * FILE NAME: UIMappingRegistry.cs
 * DESCRIPTION: 
 * A centralized registry that maps UI element names (from
 * the UI Toolkit layout) to logical commands or settings.
 * 
 * REVISION HISTORY:
 * Date [YYYY/MM/DD] | Author | Comments
 * ------------------------------------------------------------
 * 2026/02/28 | Akram Taghavi-Burris | Created class
 *
 *
 ************************************************************/
 
using System.Collections.Generic;

public static class UIMappingRegistry
{
    // COMMAND MAPPING (Used by Buttons)
    // Dictionary maps UI element names (strings) to a command type.
    
    private static readonly Dictionary<string, UICommandType> _commandMap = new()
    {
        { "playButton",  UICommandType.StartGame },
        { "quitButton",  UICommandType.QuitGame },
        { "closeButton", UICommandType.CloseMenu },
        { "masterVolumeSlider", UICommandType.MasterVolume },
        { "muteAllToggle", UICommandType.MuteAll },
    };

    
    /// <summary>
    /// Attempts to retrieve the command associated with a UI element name.
    /// </summary>
    /// <param name="elementName">
    /// The name of the UI element from the UI Toolkit layout (UXML).
    /// </param>
    /// <param name="command">
    /// When this method returns, contains the resolved <see cref="UICommandType"/>
    /// associated with the element if the lookup succeeds; otherwise contains
    /// the default value.
    /// </param>
    /// <returns>
    /// True if the element name exists in the command registry; otherwise false.
    /// </returns>
    public static bool TryGetCommand(string elementName, out UICommandType command)
    {
        return _commandMap.TryGetValue(elementName, out command);
        
    }//end TryGetCommand()

    
}//end UIMappingRegistry
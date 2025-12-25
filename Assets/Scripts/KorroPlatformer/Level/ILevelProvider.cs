using System.Collections.Generic;

namespace KorroPlatformer.Level
{
    /// <summary>
    /// Provides access to available game levels.
    /// </summary>
    public interface ILevelProvider
    {
        List<LevelData> Levels { get; }
        string MainMenuSceneName { get; }
    }
}


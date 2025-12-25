using System.Collections.Generic;
using UnityEngine;

namespace KorroPlatformer.Level
{
    /// <summary>
    /// Configuration for game levels.
    /// </summary>
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = "KorroPlatformer/Config/Level Configuration")]
    public class LevelConfiguration : ScriptableObject, ILevelProvider
    {
        [Tooltip("Name of the Main Menu scene.")]
        [field: SerializeField] public string MainMenuSceneName { get; private set; } = "MainMenu";

        [Tooltip("List of available levels.")]
        [field: SerializeField] public List<LevelData> Levels { get; private set; } = new();
    }
}

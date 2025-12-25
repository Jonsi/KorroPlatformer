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
        [SerializeField] private string _MainMenuSceneName = "MainMenu";

        [Tooltip("List of available levels.")]
        [SerializeField] private List<LevelData> _Levels = new();

        public List<LevelData> Levels => _Levels;
        public string MainMenuSceneName => _MainMenuSceneName;
    }
}


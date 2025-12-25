using System;
using UnityEngine;

namespace KorroPlatformer.Level
{
    /// <summary>
    /// Represents data for a game level.
    /// </summary>
    [Serializable]
    public class LevelData
    {
        [Tooltip("The name of the scene to load.")]
        [field: SerializeField] public string SceneName { get; private set; }
    }
}

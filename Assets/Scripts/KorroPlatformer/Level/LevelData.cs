using System;
using UnityEngine;

namespace KorroPlatformer.Level
{
    [Serializable]
    public class LevelData
    {
        [Tooltip("The name of the scene to load.")]
        [field: SerializeField] public string SceneName { get; private set; }
    }
}

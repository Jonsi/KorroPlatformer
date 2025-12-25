using System;
using UnityEngine;

namespace KorroPlatformer.Level
{
    [Serializable]
    public class LevelData
    {
        [Tooltip("The name of the scene to load.")]
        [SerializeField] private string _SceneName;
        public string SceneName => _SceneName;
    }
}


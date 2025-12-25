using UnityEngine;

namespace KorroPlatformer.Level
{
    /// <summary>
    /// Interface for managing level flow operations.
    /// </summary>
    public interface ILevelFlowManager
    {
        /// <summary>
        /// Initializes the manager.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Cleans up the manager resources.
        /// </summary>
        void Cleanup();

        /// <summary>
        /// Reloads the current level.
        /// </summary>
        Awaitable RetryLevel();

        /// <summary>
        /// Navigates to the main menu.
        /// </summary>
        Awaitable GoToMainMenu();
    }
}


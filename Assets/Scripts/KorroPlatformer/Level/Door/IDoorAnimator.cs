using UnityEngine;

namespace KorroPlatformer.Level.Door
{
    /// <summary>
    /// Interface for controlling door animations.
    /// </summary>
    public interface IDoorAnimator
    {
        /// <summary>
        /// Plays the open animation.
        /// </summary>
        /// <returns>Awaitable that completes when the animation finishes.</returns>
        Awaitable PlayOpen();
    }
}

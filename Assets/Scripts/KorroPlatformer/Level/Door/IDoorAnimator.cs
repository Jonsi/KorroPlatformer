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
        void PlayOpen();

        /// <summary>
        /// Plays the closed animation.
        /// </summary>
        void PlayClosed();
    }
}

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Interface for controlling player animations.
    /// </summary>
    public interface IPlayerAnimator
    {
        /// <summary>
        /// Plays the idle animation.
        /// </summary>
        void PlayIdle();

        /// <summary>
        /// Plays the walk animation.
        /// </summary>
        void PlayWalk();

        /// <summary>
        /// Plays the jump animation.
        /// </summary>
        void PlayJump();

        /// <summary>
        /// Plays the hit/damage animation.
        /// </summary>
        void PlayHit();

        /// <summary>
        /// Plays the death animation.
        /// </summary>
        void PlayDeath();
    }
}

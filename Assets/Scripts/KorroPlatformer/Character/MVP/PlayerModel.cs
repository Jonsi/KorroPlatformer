using Common.MVP;

namespace KorroPlatformer.Character.MVP
{
    /// <summary>
    /// Model representing the player's data (health, etc).
    /// </summary>
    public class PlayerModel : IModel
    {
        /// <summary>
        /// Gets the maximum health.
        /// </summary>
        public int MaxHealth { get; }

        /// <summary>
        /// Gets the current health.
        /// </summary>
        public int CurrentHealth { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the player is dead.
        /// </summary>
        public bool IsDead => CurrentHealth <= 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerModel"/> class.
        /// </summary>
        /// <param name="maxHealth">The maximum health of the player.</param>
        public PlayerModel(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        /// <summary>
        /// Sets the player's current health.
        /// </summary>
        /// <param name="health">The new health value.</param>
        public void SetHealth(int health)
        {
            CurrentHealth = UnityEngine.Mathf.Clamp(health, 0, MaxHealth);
        }
    }
}

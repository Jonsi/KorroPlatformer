using System;

namespace KorroPlatformer.Events
{
    /// <summary>
    /// Data payload for health change events.
    /// </summary>
    [Serializable]
    public struct HealthChangedPayload
    {
        /// <summary>
        /// The current health value.
        /// </summary>
        public int CurrentHealth;

        /// <summary>
        /// The maximum health value.
        /// </summary>
        public int MaxHealth;

        public HealthChangedPayload(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }
    }
}

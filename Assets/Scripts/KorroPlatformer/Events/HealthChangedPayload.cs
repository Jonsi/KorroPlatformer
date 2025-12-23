using System;

namespace KorroPlatformer.Events
{
    [Serializable]
    public struct HealthChangedPayload
    {
        public int CurrentHealth;
        public int MaxHealth;

        public HealthChangedPayload(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }
    }
}


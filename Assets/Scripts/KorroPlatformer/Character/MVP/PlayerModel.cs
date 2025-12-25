using Common.MVP;

namespace KorroPlatformer.Character.MVP
{
    public class PlayerModel : IModel
    {
        public int MaxHealth { get; }
        public int CurrentHealth { get; private set; }
        public bool IsDead => CurrentHealth <= 0;

        public PlayerModel(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void SetHealth(int health)
        {
            CurrentHealth = UnityEngine.Mathf.Clamp(health, 0, MaxHealth);
        }
    }
}

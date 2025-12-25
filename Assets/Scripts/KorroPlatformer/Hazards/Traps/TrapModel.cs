using Common.MVP;

namespace KorroPlatformer.Hazards.Traps
{
    /// <summary>
    /// Model for a trap.
    /// </summary>
    public class TrapModel : IModel
    {
        /// <summary>
        /// Gets the damage dealt by the trap.
        /// </summary>
        public int Damage { get; }

        public TrapModel(int damage)
        {
            Damage = damage;
        }
    }
}

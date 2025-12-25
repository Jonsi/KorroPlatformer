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

        /// <summary>
        /// Gets or sets a value indicating whether the trap is currently active/closed.
        /// </summary>
        public bool IsActive { get; set; }

        public TrapModel(int damage)
        {
            Damage = damage;
        }
    }
}

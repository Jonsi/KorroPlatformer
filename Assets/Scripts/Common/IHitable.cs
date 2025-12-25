namespace Common
{
    /// <summary>
    /// Represents an entity that can take damage.
    /// </summary>
    public interface IHitable
    {
        /// <summary>
        /// Applies damage to the entity.
        /// </summary>
        /// <param name="damage">The amount of damage to take.</param>
        void TakeDamage(int damage);
    }
}

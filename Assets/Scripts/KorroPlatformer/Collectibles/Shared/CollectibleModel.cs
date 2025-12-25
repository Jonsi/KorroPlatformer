using Common.MVP;

namespace KorroPlatformer.Collectibles.Shared
{
    /// <summary>
    /// Model representing collectible data.
    /// </summary>
    public class CollectibleModel : IModel
    {
        /// <summary>
        /// Gets the type of the collectible.
        /// </summary>
        public CollectibleType Type { get; }

        /// <summary>
        /// Gets the amount/value of the collectible.
        /// </summary>
        public int Amount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectibleModel"/> class.
        /// </summary>
        /// <param name="type">The type of collectible.</param>
        /// <param name="amount">The amount.</param>
        public CollectibleModel(CollectibleType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}

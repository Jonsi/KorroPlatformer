using KorroPlatformer.Collectibles;

namespace KorroPlatformer.Events
{
    /// <summary>
    /// Data payload for collectible events.
    /// </summary>
    public struct CollectiblePayload
    {
        /// <summary>
        /// The type of collectible collected.
        /// </summary>
        public readonly CollectibleType Type;

        /// <summary>
        /// The amount collected.
        /// </summary>
        public readonly int Amount;

        public CollectiblePayload(CollectibleType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}

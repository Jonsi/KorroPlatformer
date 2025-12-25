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
        public CollectibleType Type;

        /// <summary>
        /// The amount collected.
        /// </summary>
        public int Amount;

        public CollectiblePayload(CollectibleType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}

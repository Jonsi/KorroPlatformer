using KorroPlatformer.Collectibles;

namespace KorroPlatformer.Events
{
    public struct CollectiblePayload
    {
        public CollectibleType Type;
        public int Amount;

        public CollectiblePayload(CollectibleType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}


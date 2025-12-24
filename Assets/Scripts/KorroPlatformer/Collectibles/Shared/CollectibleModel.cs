using Common.MVP;

namespace KorroPlatformer.Collectibles.Shared
{
    public class CollectibleModel : IModel
    {
        public CollectibleType Type { get; }
        public int Amount { get; }

        public CollectibleModel(CollectibleType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}


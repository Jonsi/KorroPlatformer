using Common.MVP;

namespace KorroPlatformer.Collectibles.Coins
{
    /// <summary>
    /// Model for a Coin.
    /// </summary>
    public class CoinModel : IModel
    {
        public int Value { get; private set; }

        public CoinModel(int value)
        {
            Value = value;
        }
    }
}


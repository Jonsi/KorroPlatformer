using Common.MVP;

namespace KorroPlatformer.UI.GameUI
{
    /// <summary>
    /// Model for the Game UI, holding state for health, coins, and keys.
    /// </summary>
    public class GameUIModel : IModel
    {
        /// <summary>
        /// Gets or sets the current health value.
        /// </summary>
        public int CurrentHealth { get; set; }

        /// <summary>
        /// Gets or sets the maximum health value.
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Gets or sets the number of collected coins.
        /// </summary>
        public int CoinCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the key has been collected.
        /// </summary>
        public bool HasKey { get; set; }
    }
}


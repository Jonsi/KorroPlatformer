using Common.MVP;

namespace KorroPlatformer.UI.MainMenu.LevelItem
{
    /// <summary>
    /// Model for a level item.
    /// </summary>
    public class LevelItemModel : IModel
    {
        /// <summary>
        /// Gets the display name of the level.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the index of the level in the configuration.
        /// </summary>
        public int Index { get; }

        public LevelItemModel(string displayName, int index)
        {
            DisplayName = displayName;
            Index = index;
        }
    }
}

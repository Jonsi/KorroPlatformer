using Common.MVP;
using KorroPlatformer.Level;
using KorroPlatformer.UI.MainMenu.LevelItem;
using System.Collections.Generic;

namespace KorroPlatformer.UI.MainMenu
{
    /// <summary>
    /// Model for the Main Menu, holding the list of available levels.
    /// </summary>
    public class MainMenuModel : IModel
    {
        public List<LevelData> AvailableLevels { get; private set; } = new();
        public LevelItemView LevelItemPrefab { get; private set; }

        public MainMenuModel(List<LevelData> levels, LevelItemView levelItemPrefab)
        {
            if (levels != null)
            {
                AvailableLevels.AddRange(levels);
            }
            LevelItemPrefab = levelItemPrefab;
        }
    }
}

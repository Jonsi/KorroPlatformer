using Common.MVP;

namespace KorroPlatformer.UI.MainMenu.LevelItem
{
    public class LevelItemModel : IModel
    {
        public string DisplayName { get; }
        public int Index { get; }

        public LevelItemModel(string displayName, int index)
        {
            DisplayName = displayName;
            Index = index;
        }
    }
}


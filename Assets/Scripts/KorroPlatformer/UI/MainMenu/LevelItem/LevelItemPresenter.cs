using Common.MVP;
using System;

namespace KorroPlatformer.UI.MainMenu.LevelItem
{
    public class LevelItemPresenter : BasePresenter<LevelItemView, LevelItemModel>
    {
        public event Action<int> ItemSelected;

        public LevelItemPresenter(LevelItemView view, LevelItemModel model) : base(view, model)
        {
        }

        public void Initialize()
        {
            View.Initialize(Model);
            View.OnClick += HandleClick;
        }

        public override void Dispose()
        {
            if (View != null)
            {
                View.OnClick -= HandleClick;
            }
        }

        private void HandleClick()
        {
            ItemSelected?.Invoke(Model.Index);
        }
    }
}


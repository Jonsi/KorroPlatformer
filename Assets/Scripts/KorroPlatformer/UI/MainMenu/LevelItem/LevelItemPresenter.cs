using Common.MVP;
using System;

namespace KorroPlatformer.UI.MainMenu.LevelItem
{
    /// <summary>
    /// Presenter for a level item, handling clicks and selection.
    /// </summary>
    public class LevelItemPresenter : BasePresenter<LevelItemView, LevelItemModel>
    {
        /// <summary>
        /// Event triggered when this item is selected.
        /// </summary>
        public event Action<int> ItemSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelItemPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="model">The model.</param>
        public LevelItemPresenter(LevelItemView view, LevelItemModel model) : base(view, model)
        {
        }

        /// <summary>
        /// Initializes the presenter and view.
        /// </summary>
        public void Initialize()
        {
            View.Initialize(Model);
            View.OnClick += HandleClick;
        }

        /// <inheritdoc />
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

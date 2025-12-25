using Common;
using Common.MVP;
using UnityEngine;
using System;
using System.Collections.Generic;
using KorroPlatformer.Level;
using KorroPlatformer.UI.MainMenu.LevelItem;

namespace KorroPlatformer.UI.MainMenu
{
    /// <summary>
    /// View for the Main Menu, managing UI elements and input events.
    /// </summary>
    public class MainMenuView : MonoBehaviour, IView<MainMenuModel>
    {
        [SerializeField, Tooltip("Container transform where level buttons will be instantiated.")]
        private Transform _LevelButtonContainer;

        /// <summary>
        /// Event triggered when a level is selected.
        /// </summary>
        public event Action<int> OnLevelSelected;
        
        private readonly List<LevelItemPresenter> _ItemPresenters = new();

        /// <inheritdoc />
        public void Initialize(MainMenuModel model)
        {
            if (model.LevelItemPrefab == null || _LevelButtonContainer == null)
            {
                Debug.LogError("MainMenuView: LevelItemPrefab or Container is missing.");
                return;
            }
            
            DisplayLevels(model.AvailableLevels, model.LevelItemPrefab);
        }

        /// <inheritdoc />
        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        /// <inheritdoc />
        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        private void DisplayLevels(List<LevelData> levels, LevelItemView prefab)
        {
            ClearItems();

            for (var i = 0; i < levels.Count; i++)
            {
                var view = Instantiate(prefab, _LevelButtonContainer);
                var model = new LevelItemModel(levels[i].SceneName, i);
                var presenter = new LevelItemPresenter(view, model);
                
                presenter.ItemSelected += HandleItemSelected;
                presenter.Initialize();
                
                _ItemPresenters.Add(presenter);
            }
        }

        private void HandleItemSelected(int index)
        {
            OnLevelSelected?.Invoke(index);
        }

        private void ClearItems()
        {
            foreach (var presenter in _ItemPresenters)
            {
                presenter.ItemSelected -= HandleItemSelected;
                presenter.Dispose();
                if (presenter.View != null)
                {
                    Destroy(presenter.View.gameObject);
                }
            }
            _ItemPresenters.Clear();
        }

        private void OnDestroy()
        {
            ClearItems();
        }
    }
}

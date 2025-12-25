using Common;
using Common.MVP;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KorroPlatformer.UI.MainMenu.LevelItem
{
    /// <summary>
    /// View for a single level item in the main menu list.
    /// </summary>
    public class LevelItemView : MonoBehaviour, IView<LevelItemModel>
    {
        [SerializeField, Tooltip("Text component to display the level name.")]
        private TextMeshProUGUI _Text;

        [SerializeField, Tooltip("Button component for selecting the level.")]
        private Button _Button;

        /// <summary>
        /// Event triggered when the item is clicked.
        /// </summary>
        public event Action OnClick;

        private void Awake()
        {
            if (_Button != null)
            {
                _Button.onClick.AddListener(() => OnClick?.Invoke());
            }
        }

        /// <inheritdoc />
        public void Initialize(LevelItemModel model)
        {
            if (_Text != null)
            {
                _Text.text = model.DisplayName;
            }
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

        private void OnDestroy()
        {
            if (_Button != null)
            {
                _Button.onClick.RemoveAllListeners();
            }
        }
    }
}

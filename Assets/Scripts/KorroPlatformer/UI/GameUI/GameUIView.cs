using Common;
using Common.MVP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KorroPlatformer.UI.GameUI
{
    /// <summary>
    /// View for the Game UI, handling visual updates for health, coins, and keys.
    /// </summary>
    public class GameUIView : MonoBehaviour, IView<GameUIModel>
    {
        [SerializeField, Tooltip("Text component for displaying health.")]
        private TextMeshProUGUI _HealthText;

        [SerializeField, Tooltip("Text component for displaying coin count.")]
        private TextMeshProUGUI _CoinText;

        [SerializeField, Tooltip("Image component for the key icon.")]
        private Image _KeyIcon;

        [SerializeField, Tooltip("Color of the key icon when collected.")]
        private Color _KeyActiveColor = Color.white;

        [SerializeField, Tooltip("Color of the key icon when not collected.")]
        private Color _KeyInactiveColor = new Color(1, 1, 1, 0.3f);

        [SerializeField, Tooltip("Button to return to the main menu.")]
        private Button _BackToMenuButton;

        [Header("Result Panel")]
        [SerializeField, Tooltip("The result panel container.")]
        private GameObject _ResultPanel;

        [SerializeField, Tooltip("Text component for the result message.")]
        private TextMeshProUGUI _ResultText;

        [SerializeField, Tooltip("Button to retry the level.")]
        private Button _RetryButton;

        [SerializeField, Tooltip("Color for the result text when winning.")]
        private Color _WinColor = Color.green;

        [SerializeField, Tooltip("Color for the result text when losing.")]
        private Color _LoseColor = Color.red;

        /// <summary>
        /// Event triggered when the back to menu button is clicked.
        /// </summary>
        public event System.Action OnBackToMenuRequested;

        /// <summary>
        /// Event triggered when the retry button is clicked.
        /// </summary>
        public event System.Action OnRetryRequested;

        /// <inheritdoc />
        public void Initialize(GameUIModel model)
        {
            UpdateHealth(model.CurrentHealth, model.MaxHealth);
            UpdateCoinCount(model.CoinCount);
            UpdateKeyStatus(model.HasKey);

            if (_BackToMenuButton != null)
            {
                _BackToMenuButton.gameObject.SetActive(true);
                _BackToMenuButton.onClick.RemoveAllListeners();
                _BackToMenuButton.onClick.AddListener(() => OnBackToMenuRequested?.Invoke());
            }

            if (_RetryButton != null)
            {
                _RetryButton.onClick.RemoveAllListeners();
                _RetryButton.onClick.AddListener(() => OnRetryRequested?.Invoke());
            }
            
            if (_ResultPanel != null)
            {
                _ResultPanel.SetActive(false);
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

        /// <summary>
        /// Updates the health display.
        /// </summary>
        /// <param name="current">Current health.</param>
        /// <param name="max">Maximum health.</param>
        public void UpdateHealth(int current, int max)
        {
            if (_HealthText != null)
            {
                _HealthText.text = $"{current}/{max}";
            }
        }

        /// <summary>
        /// Updates the coin count display.
        /// </summary>
        /// <param name="count">Current coin count.</param>
        public void UpdateCoinCount(int count)
        {
            if (_CoinText != null)
            {
                _CoinText.text = $"{count}";
            }
        }

        /// <summary>
        /// Updates the key status display.
        /// </summary>
        /// <param name="hasKey">Whether the key is collected.</param>
        public void UpdateKeyStatus(bool hasKey)
        {
            if (_KeyIcon != null)
            {
                _KeyIcon.color = hasKey ? _KeyActiveColor : _KeyInactiveColor;
            }
        }

        /// <summary>
        /// Shows the result panel with the specified message.
        /// </summary>
        /// <param name="isWin">Whether the player won the level.</param>
        public void ShowResult(bool isWin)
        {
            if (_ResultPanel != null)
            {
                _ResultPanel.SetActive(true);
            }

            if (_ResultText != null)
            {
                _ResultText.text = isWin ? "Level Complete!" : "Game Over";
                _ResultText.color = isWin ? _WinColor : _LoseColor;
            }
        }
    }
}

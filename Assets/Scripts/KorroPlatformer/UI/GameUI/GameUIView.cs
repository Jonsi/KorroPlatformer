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
        [SerializeField] private TextMeshProUGUI _HealthText;
        [SerializeField] private TextMeshProUGUI _CoinText;
        [SerializeField] private Image _KeyIcon;
        [SerializeField] private Color _KeyActiveColor = Color.white;
        [SerializeField] private Color _KeyInactiveColor = new Color(1, 1, 1, 0.3f);

        /// <inheritdoc />
        public void Initialize(GameUIModel model)
        {
            UpdateHealth(model.CurrentHealth, model.MaxHealth);
            UpdateCoinCount(model.CoinCount);
            UpdateKeyStatus(model.HasKey);
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
    }
}


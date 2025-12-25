using Common;
using Common.MVP;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KorroPlatformer.UI.MainMenu.LevelItem
{
    public class LevelItemView : MonoBehaviour, IView<LevelItemModel>
    {
        [SerializeField] private TextMeshProUGUI _Text;
        [SerializeField] private Button _Button;

        public event Action OnClick;

        private void Awake()
        {
            if (_Button != null)
            {
                _Button.onClick.AddListener(() => OnClick?.Invoke());
            }
        }

        public void Initialize(LevelItemModel model)
        {
            if (_Text != null)
            {
                _Text.text = model.DisplayName;
            }
        }

        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

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


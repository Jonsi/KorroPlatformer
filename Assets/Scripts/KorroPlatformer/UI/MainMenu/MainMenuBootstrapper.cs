using KorroPlatformer.Level;
using KorroPlatformer.UI.MainMenu.LevelItem;
using UnityEngine;

namespace KorroPlatformer.UI.MainMenu
{
    /// <summary>
    /// Bootstrapper for the Main Menu scene, initializing MVP components.
    /// </summary>
    public class MainMenuBootstrapper : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the Main Menu View.")]
        private MainMenuView _View;

        [Tooltip("Configuration providing the list of available levels.")]
        [SerializeField] private LevelConfiguration _LevelConfiguration;
        
        private ILevelProvider LevelProvider => _LevelConfiguration;

        [Tooltip("Prefab used for displaying level items.")]
        [SerializeField] private LevelItemView _LevelItemPrefab;

        private MainMenuPresenter _Presenter;
        private MainMenuModel _Model;

        private void Start()
        {
            if (_View == null)
            {
                return;
            }

            if (LevelProvider == null)
            {
                return;
            }
            
            _Model = new MainMenuModel(LevelProvider.Levels, _LevelItemPrefab);
            _Presenter = new MainMenuPresenter(_View, _Model);
            _View.Initialize(_Model);
            _Presenter.Initialize();
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }
    }
}

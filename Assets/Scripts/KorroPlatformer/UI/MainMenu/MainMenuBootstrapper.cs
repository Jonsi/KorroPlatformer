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
        [SerializeField] private MainMenuView _View;
        [Tooltip("Configuration providing the list of available levels.")]
        [SerializeField] private LevelConfiguration _LevelConfiguration;
        [SerializeField] private LevelItemView _LevelItemPrefab;

        private MainMenuPresenter _Presenter;
        private MainMenuModel _Model;

        private void Start()
        {
            if (_View == null)
            {
                Debug.LogError("MainMenuBootstrapper: View is missing.");
                return;
            }

            if (_LevelConfiguration == null)
            {
                Debug.LogError("MainMenuBootstrapper: LevelConfiguration is missing.");
                return;
            }
            
            // Pass the LevelData list and Prefab to the model
            _Model = new MainMenuModel(_LevelConfiguration.Levels, _LevelItemPrefab);
            _Presenter = new MainMenuPresenter(_View, _Model);
            
            // Initialize View with Model data
            _View.Initialize(_Model);
            
            // Initialize Presenter (subscriptions)
            _Presenter.Initialize();
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }
    }
}

using Common;
using Common.MVP;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KorroPlatformer.UI.MainMenu
{
    /// <summary>
    /// Presenter for the Main Menu, handling logic and scene loading.
    /// </summary>
    public class MainMenuPresenter : BasePresenter<MainMenuView, MainMenuModel>
    {
        public MainMenuPresenter(MainMenuView view, MainMenuModel model) 
            : base(view, model)
        {
        }

        public void Initialize()
        {
            View.OnLevelSelected += HandleLevelSelected;
        }

        public override void Dispose()
        {
            if (View != null)
            {
                View.OnLevelSelected -= HandleLevelSelected;
            }
        }

        private void HandleLevelSelected(int index)
        {
            _ = HandleLevelSelectedAsync(index);
        }

        private async Awaitable HandleLevelSelectedAsync(int index)
        {
            if (index >= 0 && index < Model.AvailableLevels.Count)
            {
                var levelData = Model.AvailableLevels[index];
                if (levelData != null && !string.IsNullOrEmpty(levelData.SceneName))
                {
                    await SceneManager.LoadSceneAsync(levelData.SceneName);
                }
            }
        }
    }
}

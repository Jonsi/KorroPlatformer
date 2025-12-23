using UnityEngine;

namespace Common.MVP
{
    /// <summary>
    /// Factory interface for creating Presenters in the MVP pattern.
    /// </summary>
    /// <typeparam name="TPresenter">The type of the presenter to create.</typeparam>
    /// <typeparam name="TView">The type of the view, which must be a MonoBehaviour.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface IFactory<out TPresenter, in TView, in TModel>
        where TView : MonoBehaviour
        where TModel : IModel
    {
        /// <summary>
        /// Creates a new instance of the presenter.
        /// </summary>
        /// <param name="prefab">The view prefab to instantiate.</param>
        /// <param name="model">The model instance.</param>
        /// <param name="parent">The parent transform for the view.</param>
        /// <returns>The created presenter instance.</returns>
        TPresenter Create(TView prefab, TModel model, Transform parent);
    }
}

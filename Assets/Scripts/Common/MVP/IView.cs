using UnityEngine;

namespace Common.MVP
{
    /// <summary>
    /// Represents the View in the Model-View-Presenter pattern.
    /// Responsible for displaying data and capturing user input.
    /// </summary>
    /// <typeparam name="TModel">The type of the model associated with this view.</typeparam>
    public interface IView<TModel> where TModel : IModel
    {
        /// <summary>
        /// Initializes the view with the specified model.
        /// </summary>
        /// <param name="model">The model to initialize the view with.</param>
        void Initialize(TModel model);

        /// <summary>
        /// Shows the view asynchronously.
        /// </summary>
        /// <returns>An awaitable representing the show operation.</returns>
        Awaitable Show();

        /// <summary>
        /// Hides the view asynchronously.
        /// </summary>
        /// <returns>An awaitable representing the hide operation.</returns>
        Awaitable Hide();
    }
}

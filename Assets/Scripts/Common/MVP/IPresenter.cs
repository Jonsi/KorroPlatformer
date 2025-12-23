using System;

namespace Common.MVP
{
    /// <summary>
    /// Represents the Presenter in the Model-View-Presenter pattern.
    /// Acts as a bridge between the View and the Model.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface IPresenter<out TView, out TModel> : IDisposable
        where TView : IView<TModel>
        where TModel : IModel
    {
        /// <summary>
        /// Gets the view associated with this presenter.
        /// </summary>
        TView View { get; }

        /// <summary>
        /// Gets the model associated with this presenter.
        /// </summary>
        TModel Model { get; }
    }
}

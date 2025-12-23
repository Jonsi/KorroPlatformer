namespace Common.MVP
{
    /// <summary>
    /// Base implementation of the Presenter in the MVP pattern.
    /// Manages the lifecycle and connection between the View and Model.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class BasePresenter<TView, TModel> : IPresenter<TView, TModel>
        where TView : class, IView<TModel>
        where TModel : IModel
    {
        /// <inheritdoc />
        public TView View { get; }

        /// <inheritdoc />
        public TModel Model { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePresenter{TView, TModel}"/> class.
        /// </summary>
        /// <param name="view">The view instance.</param>
        /// <param name="model">The model instance.</param>
        protected BasePresenter(TView view, TModel model)
        {
            View = view;
            Model = model;
        }

        /// <summary>
        /// Disposes of the presenter and releases resources.
        /// </summary>
        public abstract void Dispose();
    }
}

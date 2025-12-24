namespace Common.Interaction
{
    /// <summary>
    /// Represents an object that can be interacted with by an actor.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Performs the interaction logic.
        /// </summary>
        void Interact();
    }
}

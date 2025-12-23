namespace Common.Update
{
    /// <summary>
    /// Represents an object that can be updated each frame.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Performs per-frame update logic.
        /// </summary>
        void Update();
    }
}

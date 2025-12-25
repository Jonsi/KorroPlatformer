namespace KorroPlatformer.Level.Door
{
    /// <summary>
    /// Model representing the state of a door.
    /// </summary>
    public class DoorModel : Common.MVP.IModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the door is open.
        /// </summary>
        public bool IsOpen { get; set; }
    }
}

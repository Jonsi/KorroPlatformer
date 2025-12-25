using System.Collections.Generic;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Events;
using UnityEngine;

namespace KorroPlatformer.Inventory
{
    /// <summary>
    /// Service that manages the player's inventory (coins, keys, etc.).
    /// Listens to collection events and updates its internal state.
    /// </summary>
    [CreateAssetMenu(fileName = "InventoryService", menuName = "KorroPlatformer/Services/Inventory Service")]
    public class InventoryService : ScriptableObject
    {
        [SerializeField, Tooltip("Event channel to listen for collected items.")]
        private CollectibleCollectedEvent _CollectibleCollectedEvent;
        
        private readonly Dictionary<CollectibleType, int> _Inventory = new();

        /// <summary>
        /// Gets the current number of coins.
        /// </summary>
        public int Coins => _Inventory.GetValueOrDefault(CollectibleType.Coin, 0);

        private void OnEnable()
        {
            _Inventory.Clear();
            if (_CollectibleCollectedEvent != null)
            {
                _CollectibleCollectedEvent.Subscribe(OnCollectibleCollected);
            }
        }

        private void OnDisable()
        {
            if (_CollectibleCollectedEvent != null)
            {
                _CollectibleCollectedEvent.Unsubscribe(OnCollectibleCollected);
            }
        }

        /// <summary>
        /// Checks if the inventory contains a specific item type.
        /// </summary>
        /// <param name="type">The type of item to check.</param>
        /// <returns>True if the item is in the inventory, otherwise false.</returns>
        public bool HasItem(CollectibleType type)
        {
            return _Inventory.GetValueOrDefault(type, 0) > 0;
        }

        private void OnCollectibleCollected(CollectiblePayload payload)
        {
            _Inventory.TryAdd(payload.Type, 0);
            _Inventory[payload.Type] += payload.Amount;
        }
    }
}

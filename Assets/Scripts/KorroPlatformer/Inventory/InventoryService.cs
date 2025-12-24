using System;
using System.Collections.Generic;
using KorroPlatformer.Collectibles;
using KorroPlatformer.Events;

namespace KorroPlatformer.Inventory
{
    /// <summary>
    /// Service that manages the player's inventory (coins, keys, etc.).
    /// Listens to collection events and updates its internal state.
    /// </summary>
    public class InventoryService : IDisposable
    {
        private readonly CollectibleCollectedEvent _CollectibleCollectedEvent;
        private readonly Dictionary<CollectibleType, int> _Inventory = new();
        
        public InventoryService(CollectibleCollectedEvent collectibleCollectedEvent)
        {
            _CollectibleCollectedEvent = collectibleCollectedEvent;
            if (_CollectibleCollectedEvent != null)
            {
                _CollectibleCollectedEvent.Subscribe(OnCollectibleCollected);
            }
        }

        public void Dispose()
        {
            if (_CollectibleCollectedEvent != null)
            {
                _CollectibleCollectedEvent.Unsubscribe(OnCollectibleCollected);
            }
        }

        private void OnCollectibleCollected(CollectiblePayload payload)
        {
            _Inventory.TryAdd(payload.Type, 0);
            _Inventory[payload.Type] += payload.Amount;
        }
    }
}

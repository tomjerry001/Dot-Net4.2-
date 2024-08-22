using Inventory_Management_System.Model;
using Inventory_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Service
{
    public class InventoryServiceImp : IInventoryService
    {
        // fileds
        private readonly IInventoryRepository _inventoryRepository; 

        // constructor injection
        public InventoryServiceImp(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository; 
        }
        public async Task AddInventoryAsync(Inventory inventory)
        {
           await _inventoryRepository.AddInventoryAsync(inventory); 
        }
    }
}

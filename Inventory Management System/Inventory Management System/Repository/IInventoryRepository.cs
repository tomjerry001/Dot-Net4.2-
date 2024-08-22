using Inventory_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Repository
{
    public interface IInventoryRepository
    {
        // insert
        Task AddInventoryAsync(Inventory inventory);

        // update
     //   Task UpdateInventoryAsync();

        // delete
     //   Task DeleteInventoryAsync(int id);

        // list
     //   Task<List<Inventory>> GetAllInventoryAsync();
    }
}

using CustomExceptionExample.Exceptions;
using CustomExceptionExample.Models;

namespace CustomExceptionExample.Services;

// Inventory service that demonstrates custom exceptions
public class InventoryService
{
    // Simulated database of inventory items
    private readonly Dictionary<string, InventoryItem> _inventory;

    public InventoryService()
    {
        // Initialize with some sample inventory items
        _inventory = new Dictionary<string, InventoryItem>
        {
            { "LAPTOP001", new InventoryItem("LAPTOP001", "Gaming Laptop", 2, 1200m) },
            { "MOUSE001", new InventoryItem("MOUSE001", "Wireless Mouse", 15, 25m) },
            { "KEYBOARD001", new InventoryItem("KEYBOARD001", "Mechanical Keyboard", 8, 150m) },
            { "MONITOR001", new InventoryItem("MONITOR001", "4K Monitor", 0, 800m) } // Out of stock
        };
    }

    // Method that throws OutOfStockException and InvalidQuantityException
    public void PurchaseItem(string itemId, int quantity)
    {
        // Validate quantity
        if (quantity <= 0)
        {
            throw new InvalidQuantityException(quantity);
        }

        // Check if item exists
        if (!_inventory.ContainsKey(itemId))
        {
            throw new ItemNotFoundException(itemId);
        }

        var item = _inventory[itemId];

        // Check if sufficient quantity is available
        if (item.Quantity < quantity)
        {
            throw new OutOfStockException(itemId, item.Quantity, quantity);
        }

        // Process purchase
        item.Quantity -= quantity;
        decimal totalCost = item.Price * quantity;
        Console.WriteLine($"✅ Successfully purchased {quantity} {item.Name}(s) for ${totalCost}. Remaining stock: {item.Quantity}");
    }

    // Method that throws ItemNotFoundException
    public InventoryItem GetItem(string itemId)
    {
        if (!_inventory.ContainsKey(itemId))
        {
            throw new ItemNotFoundException(itemId);
        }

        return _inventory[itemId];
    }

    // Method to get all inventory items
    public List<InventoryItem> GetAllItems()
    {
        return _inventory.Values.ToList();
    }

    // Method to add stock to an item
    public void AddStock(string itemId, int quantity)
    {
        if (quantity <= 0)
        {
            throw new InvalidQuantityException(quantity);
        }

        if (!_inventory.ContainsKey(itemId))
        {
            throw new ItemNotFoundException(itemId);
        }

        var item = _inventory[itemId];
        item.Quantity += quantity;
        Console.WriteLine($"✅ Added {quantity} units to {item.Name}. New stock: {item.Quantity}");
    }
}


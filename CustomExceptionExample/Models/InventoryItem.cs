namespace CustomExceptionExample.Models;

// Simple inventory item model
public class InventoryItem
{
    public string ItemId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public InventoryItem(string itemId, string name, int quantity, decimal price)
    {
        ItemId = itemId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}

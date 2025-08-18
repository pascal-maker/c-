namespace CustomExceptionExample.Exceptions;

// Custom exception for out of stock items
public class OutOfStockException : Exception
{
    public string ItemId { get; }
    public int AvailableQuantity { get; }
    public int RequestedQuantity { get; }

    public OutOfStockException(string itemId, int availableQuantity, int requestedQuantity)
        : base($"Item {itemId} is out of stock. Available: {availableQuantity}, Requested: {requestedQuantity}")
    {
        ItemId = itemId;
        AvailableQuantity = availableQuantity;
        RequestedQuantity = requestedQuantity;
    }

    public OutOfStockException(string message, string itemId, int availableQuantity, int requestedQuantity)
        : base(message)
    {
        ItemId = itemId;
        AvailableQuantity = availableQuantity;
        RequestedQuantity = requestedQuantity;
    }
}

// Custom exception for invalid quantities
public class InvalidQuantityException : Exception
{
    public int Quantity { get; }

    public InvalidQuantityException(int quantity)
        : base($"Invalid quantity: {quantity}. Quantity must be positive.")
    {
        Quantity = quantity;
    }

    public InvalidQuantityException(string message, int quantity)
        : base(message)
    {
        Quantity = quantity;
    }
}

// Custom exception for items not found
public class ItemNotFoundException : Exception
{
    public string ItemId { get; }

    public ItemNotFoundException(string itemId)
        : base($"Item not found: {itemId}")
    {
        ItemId = itemId;
    }

    public ItemNotFoundException(string message, string itemId)
        : base(message)
    {
        ItemId = itemId;
    }
}

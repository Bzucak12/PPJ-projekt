[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int count;

    public InventoryItem(string name, int count = 1)
    {
        itemName = name;
        this.count = count;
    }
}
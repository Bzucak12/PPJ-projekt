using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryCell : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI ItemNameDisplay;
  [SerializeField] private Image ItemImageDisplay;
  [SerializeField] private Button DropButton;

  private Item CurrentItem;
  private int Count;

  public void Initialize(ListInventory InventoryManager)
  {
    DropButton.onClick.AddListener(new UnityEngine.Events.UnityAction(delegate
    {
      InventoryManager.DropItem(gameObject);
    }));
  }

    public void AddToCount(int Amount)
    {
        Count += Amount;
        ItemNameDisplay.SetText($"{CurrentItem.ItemName} {Count}x");
    }

    public void SetItem(Item ItemToSet){
        Count = 1;
        CurrentItem = ItemToSet;
        ItemNameDisplay.SetText($"{CurrentItem.ItemName} {Count}x");
        ItemImageDisplay.sprite = ItemToSet.ItemImage;
        
    }

    public GameObject GetCellInstance() {return gameObject; }
    public Item GetItem() {return CurrentItem; }
    public int GetCount() {return Count; }

    public void RemoveCell() { Destroy(gameObject); }
}

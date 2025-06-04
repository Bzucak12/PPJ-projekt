using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public TextMeshProUGUI interactionHintText;

    public static InventoryManager Instance;

    [Header("UI")]
    public InventoryUI inventoryUI;  // odkaz na InventoryUI skript

    public Transform itemsPanel;
    public GameObject itemEntryPrefab;

    [Header("Keys")]
    public TextMeshProUGUI[] keyCounters; // 0=zlatý, 1=stříbrný, 2=bronzový

    private Dictionary<string, int> items = new Dictionary<string, int>();
    private int[] keyCounts = new int[3];

    public static event Action<string> OnItemCountChanged; // event pro změny položek

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.ToggleInventory();
        }
    }

    public void AddItem(string itemName)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName]++;
        }
        else
        {
            items[itemName] = 1;

            GameObject entry = Instantiate(itemEntryPrefab, itemsPanel);
            entry.name = itemName;

            ItemEntry ie = entry.GetComponent<ItemEntry>();
            ie.SetName(itemName);
            ie.SetCount(1);
        }

        // Aktualizuj UI
        foreach (Transform child in itemsPanel)
        {
            ItemEntry entry = child.GetComponent<ItemEntry>();
            if (entry != null && entry.itemName == itemName)
            {
                entry.SetCount(items[itemName]);
            }
        }

        OnItemCountChanged?.Invoke(itemName);
    }

    public bool UseItem(string itemName)
    {
        if (items.ContainsKey(itemName) && items[itemName] > 0)
        {
            items[itemName]--;

            // Aktualizuj UI
            foreach (Transform child in itemsPanel)
            {
                ItemEntry entry = child.GetComponent<ItemEntry>();
                if (entry != null && entry.itemName == itemName)
                {
                    entry.SetCount(items[itemName]);
                    if (items[itemName] <= 0)
                    {
                        Destroy(entry.gameObject);
                        items.Remove(itemName);
                    }
                    break;
                }
            }

            OnItemCountChanged?.Invoke(itemName);

            return true;
        }
        return false;
    }

    public int GetItemCount(string itemName)
    {
        if (items.ContainsKey(itemName))
            return items[itemName];
        return 0;
    }

    public void AddKey(KeyPickup.KeyType keyType)
    {
        int index = (int)keyType; // převedeme enum na číslo

        if (index < 0 || index >= keyCounts.Length) return;

        keyCounts[index]++;
        keyCounters[index].text = keyCounts[index] + " x";
    }
}
using UnityEngine;
using TMPro;

public class ItemEntry : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text itemCountText;

    [HideInInspector]
    public string itemName;

    public void SetCount(int count)
    {
        itemCountText.text = count + " x";
    }

    public void SetName(string name)
    {
        itemName = name;
        itemNameText.text = itemName;
    }
}
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Item", menuName = "Create new Item")]
public class Item : ScriptableObject
{
    public Sprite ItemImage;
    public string ItemName;
    
}

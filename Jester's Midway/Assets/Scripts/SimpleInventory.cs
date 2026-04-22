using System.Collections.Generic;
using UnityEngine;

public class SimpleInventory : MonoBehaviour
{
    public int tokens = 0;
    public bool hasGun = true;
}
public class ArrayInventory : PersistentSingleton<ArrayInventory>
{
    public Item[] backpack = new Item[10];
    public Item[] homeChest = new Item[64];
    public List<Item> dynamicSizeBackpack = new List<Item>();
}
[System.Serializable]
public class Item
{
    public bool isStackable = false;
}
[CreateAssetMenu(fileName = "New Item", menuName = "ItemSO/New")]
public class ItemSO : ScriptableObject
{
    public string ItemName;
    public bool isStackable = false;
    public Texture icon;
    public GameObject prefab;
}

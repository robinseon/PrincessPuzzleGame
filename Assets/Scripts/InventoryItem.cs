using UnityEngine;
//ScriptableObject used for each object in the Inventory

[CreateAssetMenu(fileName = "Item", menuName ="Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public int id;
    public string nameItem;
    public string description;
    public Sprite image;
    public bool uniqueobject;
    public bool usable;
    public int quantity;
    public int craftquantity;
    public bool crafted;
    public int numberChild;
    public int index;
}

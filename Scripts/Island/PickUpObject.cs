using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public static PickUpObject instance;
    //for stick
    public bool firstStick = false;
    public InventoryItem stick;
    //for wood
    public bool firstWood = false;
    public InventoryItem wood;
    //for stone
    public bool firstStone = false;
    public InventoryItem stone;
    //for DarkStone
    public bool firstDarkStone = false;
    public InventoryItem DarkStone;
    public int index, indexstick, indexwood, indexstone, indexdarkstone=0;
    AudioSource audioPickUp;

    public bool letter = false;
    void Awake()
    {
        instance = this;  
    }

    void Start()
    {
        audioPickUp = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stick"))
        {
            if (firstStick == false)
            {
                firstStick = true;
                Inventory.instance.content.Add(stick);
                Inventory.instance.AddInInventory(index);
                indexstick = Inventory.instance.Getindex()-1;
                Inventory.instance.content[indexstick].quantity = 1;
                Inventory.instance.content[indexstick].craftquantity = 0;
                index++;
            }
            else
            {
                if (Inventory.instance.content[indexstick].quantity == 0)
                    DisplayUsableItems.instance.AddInUsableItem(Inventory.instance.content[indexstick]);
                Inventory.instance.content[indexstick].quantity++;
            }
            Inventory.instance.UpdateText(indexstick, Inventory.instance.content[indexstick].quantity.ToString());
            Destroy(other.gameObject);
            audioPickUp.Play();
        }
        if (other.gameObject.CompareTag("Wood"))
        {
            if(firstWood==false)
            {
                firstWood = true;
                Inventory.instance.content.Add(wood);
                indexwood = Inventory.instance.Getindex() - 1;
                Inventory.instance.AddInInventory(indexwood);
                Inventory.instance.content[indexwood].quantity=1;
                Inventory.instance.content[indexwood].craftquantity = 0;
                index++;                
            }
            else
            {
                Inventory.instance.content[indexwood].quantity++;
            }
            Inventory.instance.UpdateText(indexwood, Inventory.instance.content[indexwood].quantity.ToString());
            Destroy(other.gameObject);
            audioPickUp.Play();
        }
        if (other.gameObject.CompareTag("Stone"))
        {
            if (firstStone == false)
            {
                firstStone = true;
                Inventory.instance.content.Add(stone);
                Inventory.instance.AddInInventory(index);
                indexstone = Inventory.instance.Getindex() - 1;
                Inventory.instance.content[indexstone].quantity = 1;
                Inventory.instance.content[indexstone].craftquantity = 0;
                index++;
            }
            else
            {   if(Inventory.instance.content[indexstone].quantity==0)
                    DisplayUsableItems.instance.AddInUsableItem(Inventory.instance.content[indexstone]);
                Inventory.instance.content[indexstone].quantity++;
            }
            Inventory.instance.UpdateText(indexstone, Inventory.instance.content[indexstone].quantity.ToString());
            Destroy(other.gameObject);
            audioPickUp.Play();
        }
        if (other.gameObject.CompareTag("DarkStone"))
        {
            if (firstDarkStone == false)
            {
                firstDarkStone = true;
                Inventory.instance.content.Add(DarkStone);
                indexdarkstone = Inventory.instance.Getindex() - 1;
                Inventory.instance.AddInInventory(indexdarkstone);
                Inventory.instance.content[indexdarkstone].quantity = 1;
                Inventory.instance.content[indexdarkstone].craftquantity = 0;
                index++;
            }
            else
            {
                Inventory.instance.content[indexdarkstone].quantity++;
            }
            Inventory.instance.UpdateText(indexdarkstone, Inventory.instance.content[indexdarkstone].quantity.ToString());
            Destroy(other.gameObject);
            audioPickUp.Play();
        }
        if (other.gameObject.CompareTag("Letter"))
        {
            audioPickUp.Play();
            letter = true;
            Destroy(other.gameObject);
        }
    }

    public void AddIndex()
    {
        index++;
    }
}

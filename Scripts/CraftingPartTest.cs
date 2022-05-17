using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script for the craftingPanel, to add different Materials for the craft and change the quantity with the call of the scripts ChangeQuantityCrafting
public class CraftingPartTest : MonoBehaviour
{
    public List<InventoryItem> craftingItem = new List<InventoryItem>();
    
    public static CraftingPartTest instance;

    public Sprite empty;
    public int craftingObject = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void AddItem(int index)//Add a Material in the crafting Panel, methode calls in the ChooseMaterial Script
    {
        if (index == 99)//use to remove a material and when the crafting panel is closed
        {
            for (int i = 0; i < 3; i++)
            {
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = empty;//enpty is an image

            }
            craftingObject = 0;
        }
        else
        {
            if (Inventory.instance.content[index].uniqueobject == false)//if it is not an uniqueObject, so it can bu used for the craft
            {
                if (craftingObject == 1)//craftingObject is used to know which material is it, and add in the List CraftingItem at the good index, so here for the first material
                {
                    craftingItem.Add(Inventory.instance.content[index]);
                    DisplayResult.instance.result.Add(Inventory.instance.content[index]);
                    transform.GetChild(craftingObject - 1).GetChild(0).GetComponent<Image>().sprite = Inventory.instance.content[index].image;//to change image
                    transform.GetChild(0).GetComponent<ChangeQuantityCrafting>().enabled = true;//call the script ChangeQuantityCrafting
                    Inventory.instance.content[index].craftquantity=0;
                }
                if (craftingObject > 1)
                {
                    bool alreadycrafted = false;
                    for (int i = 0; i < craftingObject - 1; i++)
                    {
                        if (craftingItem[i].id == Inventory.instance.content[index].id)//if the material is already in the craftinPanel
                        {
                            alreadycrafted = true;
                        }
                    }
                    if (alreadycrafted)
                    {
                        craftingObject--;//to not have two times the same material
                    }
                    else
                    {
                        if (craftingObject == 4)//not have more than 3 material
                        {
                            craftingItem.RemoveAt(3);
                            craftingItem.Add(Inventory.instance.content[index]);
                            DisplayResult.instance.result.Add(Inventory.instance.content[index]);
                            craftingObject--;
                        }
                        else//else add the material in the crafting panel and the list
                        {
                            craftingItem.Add(Inventory.instance.content[index]);
                            DisplayResult.instance.result.Add(Inventory.instance.content[index]);
                            transform.GetChild(craftingObject - 1).GetChild(0).GetComponent<Image>().sprite = Inventory.instance.content[index].image;
                            Inventory.instance.content[index].craftquantity = 0;
                            if (craftingObject == 2)
                            {
                                transform.GetChild(craftingObject - 1).GetComponent<ChangeQuantityCrafting1>().enabled = true;
                            }
                            else if (craftingObject == 3)
                            {
                                transform.GetChild(craftingObject - 1).GetComponent<ChangeQuantityCrafting2>().enabled = true;
                            }

                        }
                    }
                }
            }
            else//if it is an uniqueobject, not add it and stay in the same place for the material
            {
                craftingObject--;
            }


        }
    }

    public void AddComponentCrafting()
    {
        if (craftingObject == 4)
        {
            craftingObject = 4;
        }
        else
        {
            craftingObject++;

        }
        for (int i = 0; i < Inventory.instance.Getindex(); i++)//to update the text in the inventory when we have crafted an object
        {
            Inventory.instance.UpdateText(i, Inventory.instance.content[i].quantity.ToString());
        }
    }

    public void RemoveComponentCrafting()
    {
        if (craftingObject == 0)
        {
            craftingObject = 0;
        }
        else
        {
            transform.GetChild(craftingObject - 1).GetChild(0).GetComponent<Image>().sprite = empty;
            if (craftingObject == 3)
            {
                ChangeQuantityCrafting2.instance.quantity = 0;
            }
            else if (craftingObject == 2)
            {
                ChangeQuantityCrafting1.instance.quantity = 0;
            }
            else if (craftingObject == 1)
            {
                ChangeQuantityCrafting.instance.quantity = 0;
            }
            craftingObject--;
            craftingItem[craftingObject].craftquantity = 0;
            craftingItem.RemoveAt(craftingObject);
            DisplayResult.instance.result.RemoveAt(craftingObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTool : MonoBehaviour
{
    public static CraftTool instance;
    AudioSource audioCraft;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        audioCraft = GetComponent<AudioSource>();
    }

    public void craft()//methode call to craft the tool, call in DisplayResult
    {
        if(DisplayResult.instance.craft.id!=0)//if it is not the emptyItem
        {
            if (DisplayResult.instance.craft.uniqueobject)//if the GO is unique
            {
                if (DisplayResult.instance.craft.crafted == false)//check if it is not crafted and craft it one time if it is true
                {
                    Inventory.instance.content.Add(DisplayResult.instance.craft);
                    Inventory.instance.AddInInventory(Inventory.instance.Getindex() - 1);
                    DisplayResult.instance.craft.crafted = true;
                    Inventory.instance.content[Inventory.instance.Getindex() - 1].quantity = 1;
                    Inventory.instance.content[Inventory.instance.Getindex() - 1].craftquantity = 0;
                    DisplayResult.instance.craft.index = Inventory.instance.Getindex() - 1;
                    for (int i = 0; i <= CraftingPartTest.instance.craftingObject - 1; i++)//change the quantity of the components
                    {
                        CraftingPartTest.instance.craftingItem[i].quantity = CraftingPartTest.instance.craftingItem[i].quantity - CraftingPartTest.instance.craftingItem[i].craftquantity;
                    }
                }
            }
            else//if it is not unique, craft it
            {
                if (DisplayResult.instance.craft.crafted == false)
                {
                    Inventory.instance.content.Add(DisplayResult.instance.craft);
                    Inventory.instance.AddInInventory(Inventory.instance.Getindex() - 1);
                    DisplayResult.instance.craft.crafted = true;
                    DisplayResult.instance.craft.index = Inventory.instance.Getindex() - 1;
                }
                Inventory.instance.content[DisplayResult.instance.craft.index].quantity++;
                Inventory.instance.content[DisplayResult.instance.craft.index].craftquantity = 0;
                for (int i = 0; i <= CraftingPartTest.instance.craftingObject - 1; i++)//change the quantity of the components
                {
                    CraftingPartTest.instance.craftingItem[i].quantity = CraftingPartTest.instance.craftingItem[i].quantity - CraftingPartTest.instance.craftingItem[i].craftquantity;
                }
            }
        }
    }

    public void playAudioCraft()
    {
        audioCraft.Play();
    }
}

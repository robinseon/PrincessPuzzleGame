using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//in this script, there are all the Item and all the recipes for the different items of the game, so the script check if it is the good material in 
//the crafting panel with the id and compare the id with the id of each recipe and next compare the craftingQuantity. If all of this is true, 
//the Fuse button is displayed and you can clic on it.
public class DisplayResult : MonoBehaviour
{
    public static DisplayResult instance;
    public InventoryItem craft;//Item which will be crafted at the end with the methode craft
    public InventoryItem nothing;
    public InventoryItem wood;
    public InventoryItem stone;
    public InventoryItem darkstone;
    public InventoryItem pickAxe;
    public InventoryItem axe;
    public InventoryItem woodenPlack;
    public InventoryItem pole;
    public InventoryItem barrier;
    public InventoryItem bridge;
    public InventoryItem hammer;
    public InventoryItem key;

    public List<InventoryItem> result = new List<InventoryItem>();
    public List<InventoryItem> resultSort = new List<InventoryItem>();
    public List<InventoryItem> recepeAxePickAxe = new List<InventoryItem>();
    public List<InventoryItem> recepewoodenPlank = new List<InventoryItem>();
    public List<InventoryItem> recepePole = new List<InventoryItem>();
    public List<InventoryItem> recepeBarrier = new List<InventoryItem>();
    public List<InventoryItem> recepeBridge = new List<InventoryItem>();
    public List<InventoryItem> recepeHammer = new List<InventoryItem>();
    public List<InventoryItem> recepeKey = new List<InventoryItem>();

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pickAxe.crafted = false;
        axe.crafted = false;
        hammer.crafted = false;
        woodenPlack.quantity = 0;
        woodenPlack.crafted = false;
        pole.quantity = 0;
        pole.crafted = false;
        barrier.quantity = 0;
        barrier.crafted = false;
        bridge.crafted = false;
        bridge.quantity = 0;
        key.crafted = false;
        key.quantity = 0;
    }



    public void sortResult()
    {
        resultSort.Clear();
        for(int i=0; i<=CraftingPartTest.instance.craftingObject-1;i++)
        {
            resultSort.Add(result[i]);
        }
        resultSort.Sort(SortById);
        FillList();
        checkRecepe();
        displayButtonFuse();
    }

    public void FillList()
    {
        for (int i=CraftingPartTest.instance.craftingObject - 1; i<2; i++)
        {
            resultSort.Add(nothing);
        }
    }

    public void checkRecepe()
    {
        int recepeAxePickAxeTrue = 0;
        int recepeWoodenPlankTrue = 0;
        int recepePoleTrue = 0;
        int recepeBarrierTrue = 0;
        int recepeBridgeTrue = 0;
        int recepeHammerTrue = 0;
        int recepeKeyTrue = 0;
        for (int i=0; i<=2; i++)
        {
            if(resultSort[i].id==recepeAxePickAxe[i].id)
            {
                 recepeAxePickAxeTrue++;
            }
            if (resultSort[i].id == recepewoodenPlank[i].id)
            {
                recepeWoodenPlankTrue++;
            }
            if (resultSort[i].id == recepePole[i].id)
            {
                recepePoleTrue++;
            }
            if (resultSort[i].id == recepeBarrier[i].id)
            {
                recepeBarrierTrue++;
            }
            if (resultSort[i].id == recepeBridge[i].id)
            {
                recepeBridgeTrue++;
            }
            if (resultSort[i].id == recepeHammer[i].id)
            {
                recepeHammerTrue++;
            }
            if (resultSort[i].id == recepeKey[i].id)
            {
                recepeKeyTrue++;
            }
        }
        if(recepeAxePickAxeTrue == 3)
        {
            if (resultSort[0].craftquantity == 1 && resultSort[1].craftquantity == 3)
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = pickAxe.image;
                craft = pickAxe;
            }  
            else if (resultSort[0].craftquantity == 1 && resultSort[1].craftquantity == 2)
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = axe.image;
                craft = axe;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
                craft = nothing;
            }
        }
        else if (recepeWoodenPlankTrue == 3)
        {
            if (resultSort[0].craftquantity == 1 && resultSort[1].craftquantity == 2) 
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = woodenPlack.image;
                craft = woodenPlack;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
                craft = nothing;
            }
        }
        else if (recepePoleTrue == 3)
        {
            if (resultSort[0].craftquantity == 2 && resultSort[1].craftquantity == 5 && resultSort[2].craftquantity == 2)
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = pole.image;
                craft = pole;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
                craft = nothing;
            }
        }
        else if (recepeBarrierTrue == 3)
        {
            if (resultSort[0].craftquantity == 7 && resultSort[1].craftquantity == 4)
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = barrier.image;
                craft = barrier;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
                craft = nothing;
            }
        }
        else if (recepeBridgeTrue == 3)
        {
            if (resultSort[0].craftquantity == 7 && resultSort[1].craftquantity == 4 && resultSort[2].craftquantity == 2)
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = bridge.image;
                craft = bridge;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
                craft = nothing;
            }
        }
        else if (recepeKeyTrue == 3)
        {
            if (resultSort[0].craftquantity == 2)
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = key.image;
                craft = key;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
                craft = nothing;
            }
        }
        else if (recepeHammerTrue == 3)
        {
            if (resultSort[0].craftquantity == 1 && resultSort[1].craftquantity == 1 && resultSort[2].craftquantity == 2)
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = hammer.image;
                craft = hammer;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
                craft = nothing;
            }
        }
        else
        {
            transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
            craft = nothing;
        }
    }

    public void displayButtonFuse()
    {
        if(craft.crafted==true && craft.uniqueobject==true || craft.id==0 || resultSort[0].craftquantity > resultSort[0].quantity || resultSort[1].craftquantity > resultSort[1].quantity || resultSort[2].craftquantity > resultSort[2].quantity)
        {
            transform.GetChild(0).GetChild(1).GetComponent<Button>().enabled = false;
            transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().enabled = false;
        }
        else
        {
            transform.GetChild(0).GetChild(1).GetComponent<Button>().enabled = true;
            transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().enabled = true;
        }
    }
    public void resetDisplay()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = nothing.image;
        craft = nothing;
    }

    static int SortById(InventoryItem i1, InventoryItem i2)//function to compare the id of the item
    {
        return i1.id.CompareTo(i2.id);
    }
}

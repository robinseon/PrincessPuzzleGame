using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script for the first material in the CraftingPanel
public class ChangeQuantityCrafting : MonoBehaviour
{
    public static ChangeQuantityCrafting instance;
    public int quantity = 1;

    private void Awake()
    {
        instance = this;
    }
    public void AddComponent()//methode for the + button of the material, add craftquantity on the scriptable object if it is less than the maximum quantity
    {
        if(quantity<CraftingPartTest.instance.craftingItem[0].quantity)
        {
            quantity++;
        }
        else
        {
            quantity = CraftingPartTest.instance.craftingItem[0].quantity;
        }
        CraftingPartTest.instance.craftingItem[0].craftquantity = quantity;
    }

    public void RemoveComponent()//methode for the - button of the material, remove craftquantity on the scriptable object if it is more than 0
    {
        if (quantity > 1)
        {
            quantity--;
        }
        else
        {
            quantity = 1;
        }
        CraftingPartTest.instance.craftingItem[0].craftquantity = quantity;
    }

    void Update()//change the text of the first material
    {
        transform.GetChild(1).GetComponent<Text>().text = quantity.ToString();
        if (Input.GetKeyDown(KeyCode.C))
        {
            quantity = 0;
            CraftingPartTest.instance.craftingItem[0].craftquantity = quantity;
        }
    }
}

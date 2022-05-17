using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//same script than ChangeQuantityCrafting bur for the scond material of the CraftingPanel, so with the index 1
public class ChangeQuantityCrafting1 : MonoBehaviour
{
    public int quantity = 1;
    public static ChangeQuantityCrafting1 instance;


    private void Awake()
    {
        instance = this;
    }
    public void AddComponent()
    {
        if (quantity < CraftingPartTest.instance.craftingItem[1].quantity)
        {
            quantity++;
        }
        else
        {
            quantity = CraftingPartTest.instance.craftingItem[1].quantity;
        }
        CraftingPartTest.instance.craftingItem[1].craftquantity = quantity;
    }

    public void RemoveComponent()
    {
        if (quantity > 1)
        {
            quantity--;
        }
        else
        {
            quantity = 1;
        }
        CraftingPartTest.instance.craftingItem[1].craftquantity = quantity;
    }

    void Update()
    {
        transform.GetChild(1).GetComponent<Text>().text = quantity.ToString();
        if (Input.GetKeyDown(KeyCode.C))
        {
            quantity = 0;
            CraftingPartTest.instance.craftingItem[1].craftquantity = quantity;
        }
    }
}

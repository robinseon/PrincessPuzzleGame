using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//same script than ChangeQuantityCrafting bur for the scond material of the CraftingPanel, so with the index 2
public class ChangeQuantityCrafting2 : MonoBehaviour
{
    public int quantity = 0;
    public static ChangeQuantityCrafting2 instance;


    private void Awake()
    {
        instance = this;
    }
    public void AddComponent()
    {
        if (quantity < CraftingPartTest.instance.craftingItem[2].quantity)
        {
            quantity++;
        }
        else
        {
            quantity = CraftingPartTest.instance.craftingItem[2].quantity;
        }
        CraftingPartTest.instance.craftingItem[2].craftquantity = quantity;
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
        CraftingPartTest.instance.craftingItem[2].craftquantity = quantity;
    }

    void Update()
    {
        transform.GetChild(1).GetComponent<Text>().text = quantity.ToString();
        if (Input.GetKeyDown(KeyCode.C))
        {
            quantity = 0;
            CraftingPartTest.instance.craftingItem[2].craftquantity = quantity;
        }
    }
}

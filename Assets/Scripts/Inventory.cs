using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public int woodCount;
    public int stoneCount;
    public int darkstoneCount;
    public bool inventoryDisplay;

    public static Inventory instance;
    public List<InventoryItem> content = new List<InventoryItem>();

    GameObject P; //Inventory_Panel
    GameObject S;//stuff
    public int[] slot;
    AudioSource audioInventory;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inventoryDisplay = false;
        audioInventory = GetComponent<AudioSource>();
        //to have an array for each slot int the inventory
        P = transform.GetChild(0).gameObject;//To have the panel
        S = P.transform.GetChild(0).gameObject;//and next, the children in slot
        slot = new int[S.transform.childCount];//and change the size off the array with the number of slot
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))//to open and close the iventory and display the cursor if the Inventory is open with the cratingPanel
        {
            inventoryDisplay = !inventoryDisplay;
            GetComponent<Canvas>().enabled = inventoryDisplay;
            audioInventory.Play();
            if (OpenCrafting.instance.craftingDisplay == true && inventoryDisplay)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (OpenCrafting.instance.craftingDisplay == true && inventoryDisplay==false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            for(int i=0; i<Getindex();i++)//to update the text in the inventory when we have crafted an object
            {
                UpdateText(i, content[i].quantity.ToString());
            }
        }
    }

    public void AddInInventory(int index)//Add an Item in the inventory
    {
        S.transform.GetChild(index).GetChild(0).GetComponent<Image>().sprite = content[index].image;
        S.transform.GetChild(index).GetChild(1).GetComponent<Text>().enabled = true;
        DisplayUsableItems.instance.AddInUsableItem(content[index]);
    }

    public void UpdateText(int index, string txt)
    {
        S.transform.GetChild(index).GetChild(1).GetComponent<Text>().text = txt;
    }

    public void CloseInventory()
    {
        inventoryDisplay = false;
        GetComponent<Canvas>().enabled = inventoryDisplay;
    }

    public int Getindex()
    {
        int ind = content.Count;
        return ind;
    }
}

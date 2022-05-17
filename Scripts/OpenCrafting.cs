using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCrafting : MonoBehaviour
{
    public GameObject inventory;
    public GameObject crafting;
    public static OpenCrafting instance;

    public bool craftingDisplay;
    public bool inventoryDisplay;

    AudioSource craftingAudio;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        craftingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//to open and close the crafting panel and remove component if it is closed
        {
            craftingDisplay = !craftingDisplay;
            if (craftingDisplay)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                CraftingPartTest.instance.AddItem(99);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            GetComponent<Canvas>().enabled = craftingDisplay;
            CraftingPartTest.instance.craftingObject = 0;
            CraftingPartTest.instance.craftingItem.Clear();
            DisplayResult.instance.result.Clear();
            DisplayResult.instance.resetDisplay();
            craftingAudio.Play();
        }
    }

    public void OpenInventory()//use when a button is cliked on the crafting
    {
        inventoryDisplay = true;
        inventory.GetComponent<Canvas>().enabled = inventoryDisplay;
        craftingAudio.Play();
    }
}

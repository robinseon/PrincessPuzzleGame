using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//change the usableItem on teh display on the top right of the screenwhen the button Q or E are pressed
public class DisplayUsableItems : MonoBehaviour
{
    public static DisplayUsableItems instance;
    public List<InventoryItem> usableItem = new List<InventoryItem>();
    bool firstUsableItem = false;
    public int changedisplay = 0;
    public int maxIndex, minIndex = 0;
    public int lastTool = 0;
    public InventoryItem inTheHand;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inTheHand = usableItem[0];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(changedisplay<maxIndex)
            {
                changedisplay++;
            }
            else
            {
                changedisplay = minIndex;
            }
            DisplayItems(changedisplay);
            ChangeTool.instance.ChangeUsableTool(usableItem[changedisplay].numberChild, firstUsableItem, lastTool);
            lastTool = usableItem[changedisplay].numberChild;
            inTheHand = usableItem[changedisplay];
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (changedisplay > minIndex)
            {
                changedisplay--;
            }
            else
            {
                changedisplay = maxIndex;
            }
            DisplayItems(changedisplay);
            ChangeTool.instance.ChangeUsableTool(usableItem[changedisplay].numberChild, firstUsableItem, lastTool);
            lastTool = usableItem[changedisplay].numberChild;
            inTheHand = usableItem[changedisplay];
        }
        RemoveUsableItem();
    }

    public void AddInUsableItem(InventoryItem item)
    {
        if (item.usable==true)//Add in the list of the Usable Item
        {
            usableItem.Add(item);
            maxIndex = usableItem.Count-1;
        }
        if(firstUsableItem==false)//if it is the first usableItem, display it in the Hand
        {
            changedisplay = 1;
            minIndex = 1;
            firstUsableItem = true;
            DisplayItems(changedisplay);
            ChangeTool.instance.ChangeUsableTool(usableItem[changedisplay].numberChild, firstUsableItem, lastTool);
            lastTool = usableItem[changedisplay].numberChild;
            inTheHand = usableItem[changedisplay];
        }
    }

    public void DisplayItems(int index)//call each time a key is pressed 
    {
        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = usableItem[index].image;
    }

    public void RemoveUsableItem()//if the quantity of a GO is = to 0, remove it from the list
    {
        for(int i=0; i<usableItem.Count;i++)
        {
            if(usableItem[i].quantity==0)
            {
                usableItem.RemoveAt(i);
                maxIndex--;
                changedisplay = minIndex;
                inTheHand = usableItem[changedisplay];
                ChangeTool.instance.ChangeUsableTool(usableItem[changedisplay].numberChild, firstUsableItem, lastTool);
                DisplayItems(changedisplay);
                lastTool = usableItem[changedisplay].numberChild;
            }
        }
    }

}

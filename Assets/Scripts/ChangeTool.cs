using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to change the tool on the hand of the player, with the methode ChangeUsableTool
public class ChangeTool : MonoBehaviour
{
    public static ChangeTool instance;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void ChangeUsableTool(int nbChild, bool firstItem, int lasttool)
    {
        if (firstItem == false)//display the stick in the hand when it is collected
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject camera = player.transform.GetChild(1).gameObject;
            GameObject tool = camera.transform.GetChild(nbChild).gameObject;
            tool.SetActive(true);
        }
        else//change the tool with the new one
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject camera = player.transform.GetChild(1).gameObject;
            GameObject tool = camera.transform.GetChild(lasttool).gameObject;
            tool.SetActive(false);
            tool = camera.transform.GetChild(nbChild).gameObject;
            tool.SetActive(true);
        }   
    }
}

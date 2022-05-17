using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to display the letter whenthe key L is pressed
public class OpenLetter : MonoBehaviour
{
    public GameObject player;
    public AudioSource openLetter;
    bool letterDisplay;
    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PickUpObject>().letter)
        {
            if(Input.GetKeyDown(KeyCode.L))
            {
                letterDisplay = !letterDisplay;
                GetComponent<Canvas>().enabled = letterDisplay;
                openLetter.Play();
            }
        }
    }
}

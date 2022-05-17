using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//open the menu in the game when the key Escape is pressed
public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    public bool menuDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuDisplay = !menuDisplay;
            if(menuDisplay)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                menu.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                menu.SetActive(false);
            }
        }
    }
}

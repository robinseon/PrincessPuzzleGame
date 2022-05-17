using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//for the Panel at the end of the game
public class EndGame : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetChild(4).GetComponent<Text>().text = player.GetComponent<Action>().die.ToString();
        player.GetComponent<Action>().stopMove = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

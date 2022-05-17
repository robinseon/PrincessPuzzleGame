using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public static OpenDoor instance;
    Animator anim;
    public int canInterract = 0;
    public bool opened;
    public GameObject zoneDetection;
    AudioSource audioDoor1;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        opened = false;
        zoneDetection.GetComponent<GuardDetection>().enabled = true;
        audioDoor1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInterract == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               if(opened==false)
                {
                    anim.SetFloat("Open",1);
                    opened = true; 
                    zoneDetection.SetActive(true);
                }
               else
                {
                    anim.SetFloat("Open", 0);
                    opened = false;
                    zoneDetection.SetActive(false);
                }
                audioDoor1.Play();
            }
        }
    }
}

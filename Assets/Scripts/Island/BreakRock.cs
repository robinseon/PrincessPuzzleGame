using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code used to break the normal Rock and the DarkRock
public class BreakRock : MonoBehaviour
{
    public GameObject collectible;
    public Animator animBreakStone;
    public Animator animBreakDarkStone;
    AudioSource audioRock;
    public int canInterract = 0;
    int hit;
    // Start is called before the first frame update
    void Start()
    {
        audioRock = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInterract == 1 && (DisplayUsableItems.instance.inTheHand.id == 1 || DisplayUsableItems.instance.inTheHand.id == 11))//does the player have stick (id:1) or pickaxe (id:11) in hand which are neccessary to destroy a rock?
        {
            if (DisplayUsableItems.instance.inTheHand.id == 1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    audioRock.Play();
                    StartCoroutine("WaitThreeSeconds");
                    animBreakStone.SetTrigger("Break");
                }
            }
            else if(DisplayUsableItems.instance.inTheHand.id == 11)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    audioRock.Play();
                    StartCoroutine("Wait1Seconds");
                    StartCoroutine("WaitThreeSeconds");
                    animBreakDarkStone.SetTrigger("Break");
                }
            }
        }
    }

    IEnumerator WaitThreeSeconds() 
    {
        yield return new WaitForSeconds(3);
        collectible.SetActive(true);
        gameObject.SetActive(false);
    }
    IEnumerator Wait1Seconds()
    {
        yield return new WaitForSeconds(1);
        audioRock.Play();
        hit++;
        if(hit<2)
            StartCoroutine("Wait1Seconds");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public Animator destroyWall;
    public int canInterract;
    AudioSource audioWall;
    int hit;
    // Start is called before the first frame update
    void Start()
    {
        audioWall = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInterract == 1)// && (DisplayUsableItems.instance.inTheHand.id == 12))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioWall.Play();
                destroyWall.SetTrigger("Destroy");
                StartCoroutine("WaitOneSecond");
            }
        }
    }
    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}

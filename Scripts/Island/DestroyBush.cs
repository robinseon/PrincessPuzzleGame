using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBush : MonoBehaviour
{
    public GameObject collectible;
    AudioSource audioBush;
    public int canInterract = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioBush = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInterract == 1)//to choose the good bush to destroy
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioBush.Play();
                StartCoroutine("WaitSeconds");
                
            }
        }
    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(0.2f);
        collectible.SetActive(true);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBridge : MonoBehaviour
{
    public GameObject bridge;
    public int canInterract;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInterract == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                for (int i = 0; i < Inventory.instance.Getindex(); i++)//check if the bridge is built
                {
                    if (Inventory.instance.content[i].id == 8)
                        if (Inventory.instance.content[i].quantity == 1)
                            Inventory.instance.content[i].quantity--;
                }
                bridge.SetActive(true);
                StartCoroutine("OnCompleteAnimation");
            }
        }
    }

    IEnumerator OnCompleteAnimation()
    {
        while (bridge.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;

        // TODO: Do something when animation did complete;
        anim.enabled=true;
        bridge.GetComponent<Animator>().enabled = false;
    }
}

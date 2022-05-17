using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDetection : MonoBehaviour
{
    public static GuardDetection instance;
    public GameObject player;
    public GameObject zoneDetection;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = Action.instance.reStartPosition;
            AudioManager.instance.RespawnMusic();
            zoneDetection.SetActive(true);
            player.transform.GetComponent<Action>().die++;
        }
    }
    
}

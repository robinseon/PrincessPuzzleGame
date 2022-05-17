using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStone : MonoBehaviour
{
    public static ThrowStone instance;
    public Transform playerCamera;
    public GameObject stone;
    public GameObject player;
    GameObject stoneT;//will be the clone
    public InventoryItem stoneItem;
    bool destrystone=false;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stoneT = Instantiate(stone, transform.position, Quaternion.identity);
                Rigidbody rbStoneClone = stoneT.GetComponent<Rigidbody>();
                rbStoneClone.useGravity = true;
                stoneT.GetComponent<Rigidbody>().AddForce(playerCamera.forward * 10, ForceMode.VelocityChange);
                destrystone = false;
            }
            if (stoneT != null)
            {
                if (stoneT.transform.position.y <= player.transform.position.y - 0.5f)
                {
                    MoveGuard.instance.GetDistance(stoneT);
                    MoveGuard.instance.GetPositionStone(stoneT);
                    StartCoroutine("Wait01Second");
                }
            }
    }
    IEnumerator Wait01Second() 
    {
        yield return new WaitForSeconds(0.1f);
        if(destrystone==false)
        {
            Destroy(stoneT);
            stoneItem.quantity--;
            destrystone = true;
            stoneT = null;
        }
    }
}

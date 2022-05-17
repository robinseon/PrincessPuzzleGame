using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_collectible : MonoBehaviour
{
    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = tree.transform.position;
        transform.eulerAngles = new Vector3(0, tree.transform.eulerAngles.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

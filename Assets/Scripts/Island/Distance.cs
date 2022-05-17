using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public static Distance instance;
    void Awake()
    {
        instance = this; 
    }

    public float CalculateDistance(GameObject stone)
    {
        return Vector3.Distance(transform.position, stone.transform.position);
    }
}

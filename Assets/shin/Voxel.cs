using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{

    public float speed = 5;
    
    void Start()
    {
        Vector3 direction = Random.insideUnitSphere;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    
    void Update()
    {
        
    }
}

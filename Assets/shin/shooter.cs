using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class shooter : MonoBehaviour
{

    public float speed = 3f;
    //public Transform target;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //Vector3 relativePos = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Meteo"))
        {
            Destroy(gameObject);
            Debug.Log("bullet detect meteo");
        }
    }
}

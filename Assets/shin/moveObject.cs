using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    public GameObject target;

    public float move_sensitivity = 0.3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            this.transform.Translate(-0.1f * move_sensitivity, 0.0f, 0.0f);
            Debug.Log("Left (of keyboard)");
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            this.transform.Translate(0.1f * move_sensitivity, 0.0f, 0.0f);
            Debug.Log("Right (of keyboard)");
        }
    }
}

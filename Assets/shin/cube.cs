using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public float speed = 1f;

    // �̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵�
    void move()
    {
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(-0.1f * speed, 0, 0);

        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(0.1f * speed, 0, 0);

        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0, 0, 0.1f * speed);

        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(0, 0, -0.1f * speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}

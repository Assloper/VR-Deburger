using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float offset = 3f; // 그냥 아무 값이 필요했음. z축 땜빵용;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseCursorPos = Input.mousePosition;
        mouseCursorPos.z = offset;
        transform.position = mouseCursorPos;
    }
}

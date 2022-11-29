using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Camera mainCamera;
    Vector3 angle;
    public float sensitivity = 200;
    public float speed = 0f;
    public float zoomSpeed = 10.0f; // �ΰ�����

    // ���ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ����ξƿ�
    void zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }

    // ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��ȸ��
    void rotate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            angle.z += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle.z -= 1;
        }

        transform.eulerAngles = new Vector3(-angle.y, angle.x, angle.z);
    }

    // �̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵��̵�
    void move()
    {
        /*if (ARAVR.Axis2D.)
        {
            }
*/

        this.transform.Translate(ARAVRInput.GetAxis("Horizontal"), 0, 0);


        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.1f * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(0, 0, 0.1f * speed);

        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(0, 0, -0.1f * speed);
    }


    // ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ��ŸƮ
    void Start()
    {

        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(0, 0, 0);

        mainCamera = GetComponent<Camera>();
    }

    // ��������������������������������������������������������������������������������������������������������������������������������
    void Update()
    {
        rotate();
        move();
        zoom();
    }
}

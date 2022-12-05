using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody rigidbody;
    Camera mainCamera;
    Vector3 angle;

    public float speed = 10f;


    public float zoomSpeed = 10.0f;
    void zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }

    public float yaw_sensitivity = 20f;
    public float limitAngle = 45; 
    public float sensitivity_forMouse = 200;
    void rotate()
    {
/*        // 마우스 좌표에 따라 시야가 도는 블럭
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        angle.x += x * sensitivity_forMouse * Time.deltaTime;
        angle.y += y * sensitivity_forMouse * Time.deltaTime;*/

        if (Input.GetKey(KeyCode.A) && angle.z < limitAngle) 
        {
            angle.z += 0.1f; 
            transform.Rotate(new Vector3(0,-1,0) * Time.deltaTime * yaw_sensitivity);
        }
        if (Input.GetKey(KeyCode.D) && angle.z > -limitAngle)
        {
            angle.z -= 0.1f;
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * yaw_sensitivity);
        }
        transform.Rotate(0, 0, angle.z/100);
    }

    // Move
    void move()
    {
/*
        // 실습용이었던걸 떼온것, 참고용도
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //Vector3 relativePos = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos);
*/

           
/*        if (Input.GetKey(KeyCode.A))                        // move to left, keyboard 'A'
            this.transform.Translate(-0.1f * speed, 0, 0);
        if (Input.GetKey(KeyCode.D))                        // move to right, keyboard 'D'      
            this.transform.Translate(0.1f * speed, 0, 0);
        if (Input.GetKey(KeyCode.S))                        // move to back, keyboard 'S'
            this.transform.Translate(0, 0, -0.1f * speed);
*/

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate((-angle.z / 1000), -transform.position.y, 0);     // roll 각도에 따라 추가적으로 horizontal 이동하는 코드. 즉, 기울어진 방향으로 약간 이동하는 코드 + y축 이동을 막는 코드
            rigidbody.velocity = transform.forward * speed;

        }

        Camera.main.transform.position = transform.position;    // 카메라가 따라오게 함
        Camera.main.transform.Translate(0, 5.8f, 0);
    }


    void Start()
    {

        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(0, 0, 0);

        mainCamera = GetComponent<Camera>();


        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotate();
        move();
        zoom();
    }
}

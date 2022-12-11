using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Gun Gun;
    public GameObject target;
    
   public float move_sensitivity = 0.3f;

    Rigidbody rigidbody;
    Camera mainCamera;
    public Vector3 angle;


    public float speed = 0.1f;
    public float zoomSpeed = 10.0f;
    void zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }

    public float roll_sensitivity = 0.5f;
    public float yaw_sensitivity = 0.3f;
    public float limitAngle = 2;
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
            angle.z += roll_sensitivity;

        }

        if (Input.GetKey(KeyCode.D) && angle.z > -limitAngle)
        {
            angle.z -= roll_sensitivity;

        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))   // 아무입력도 없을때, 정상각도로 돌아감
        {
            if (angle.z < 0)
            {
                angle.z += 0.1f;

            }
            else if (angle.z > 0)
            {
                angle.z -= 0.1f;

            }

        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle.y -= yaw_sensitivity;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle.y += yaw_sensitivity;
        }

        transform.rotation = Quaternion.Euler(0, angle.y, angle.z);

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


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.2f, 0, 0);   // 조금씩 이동
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.2f, 0, 0);   // 조금씩 이동
        }

        if (Input.GetKey(KeyCode.S))                        // move to back, keyboard 'S'
            this.transform.Translate(0, 0, -0.1f * speed);


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((-angle.z / 100), 0, speed);     // roll 각도에 따라 추가적으로 horizontal 이동하는 코드. 즉, 기울어진 방향으로 약간 이동하는 코드 + y축 이동을 막는 코드
            //rigidbody.velocity = transform.forward * speed;

        }

        Camera.main.transform.position = transform.position;    // 카메라가 따라오게 함
        //Camera.main.transform.Translate(0, 5.8f, 0);  // 
        Camera.main.transform.Translate(0, 0.9f, -3);
        transform.Translate(0, -transform.position.y, 0);
        Camera.main.transform.rotation = Quaternion.Euler(0, angle.y, 0);
    }

    void Thumb()    // 드럼스틱(조이스틱)임
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            var absX = Mathf.Abs(thumbstick.x);
            var absY = Mathf.Abs(thumbstick.y);

            if (absX > absY)
            {
                if (thumbstick.x > 0)
                {
                    target.transform.Translate(0.1f * move_sensitivity, 0, 0);

                }
                else
                {
                    target.transform.Translate(-0.1f * move_sensitivity, 0, 0);
                }
            }
            else
            {
                if (thumbstick.y > 0)
                {
                    target.transform.Translate(0, 0, move_sensitivity * 0.1f);
                }
                else
                {
                    target.transform.Translate(0, 0, -0.1f * move_sensitivity);
                }
            }
        }
    }

    void Trigger()  // 오큘 컨트롤러 뒤에있는 트리거임
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("trigger");
        }
    }

    // pc용 컨트롤
    void moveForPC()
    {
        if (Input.GetKey(KeyCode.LeftArrow))    // 좌이동임
        {
            this.transform.Translate(-0.1f * move_sensitivity, 0.0f, 0.0f);
            Debug.Log("Left (of keyboard)");
        }

        if (Input.GetKey(KeyCode.RightArrow))   //우이동임
        {
            this.transform.Translate(0.1f * move_sensitivity, 0.0f, 0.0f);
            Debug.Log("Right (of keyboard)");
        }
    }





    

    //AudioSource audioSource;

    void Start()
    {
        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(0, 0, 0);

        mainCamera = GetComponent<Camera>();


        rigidbody = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        move();
        zoom();
        Gun.Shoot();
        
        /*        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo = new RaycastHit();*/
        /*
                좌 컨트롤러 : 회전담당
                우 컨트롤러: 이동담당

                회전은,
                전부 최대 + -40도정도,
                vertical은 pitch 축

                horizontal은 roll 축을 움직이되, 이후 전진 시 좌우 이동에 roll축 값이 반영됨
                (기울이고 전진하면 우측으로 추가적으로 이동됨), 
        */

        Thumb();
        Trigger();

/*        // 디버깅용임
        if (Input.GetKeyDown(KeyCode.Return))   // Return은 Enter임
        {
            audioSource.Stop();
            audioSource.Play();
        }
        Debug.Log(audioSource.time);*/

    }
}

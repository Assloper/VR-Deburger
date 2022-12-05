using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    /*public Transform target2;*/
    public GameObject bullet;
    public float bullet_speed = 5000;       // 탄속
    public float bullet_cooldown_Interval = 0.3f;    // 총알 쿨다운
    float timer_cooldown = 0;               // 쿨다운을 위한 타이머

    public bool Shooter_Shoot()
    {
        if (timer_cooldown >= bullet_cooldown_Interval) {
            if (ARAVRInput.GetDown(ARAVRInput.Button.One) || Input.GetKey(KeyCode.Space))
            {
                //Physics.Raycast(ray, out hitInfo);
                GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject; // 생성과 동시에 좌표 및 방향 벡터정보를 이미 넘겨줌
                                                                                                                    //projectile.transform.position = hitInfo.point;                     // 이미 Instantiate에서 정의된 부분
                                                                                                                    //projectile.transform.position = this.transform.position;          //  위와 비슷한 내용
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * bullet_speed);
                Destroy(projectile, 2);
                timer_cooldown = 0;

                return true;
            }else
            {
                return false;
            }
        } else
        {
            return false;   // Shoot 실패의 경우 false return
        }

    }










    // 오큘러스를 위한 컨트롤
    public GameObject target;
    public float move_sensitivity = 0.3f;

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







    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shooter_Shoot();
        timer_cooldown += Time.deltaTime;
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

        // 디버깅용임
        if (Input.GetKeyDown(KeyCode.Return))   // Return은 Enter임
        {
            audioSource.Stop();
            audioSource.Play();
        }
        Debug.Log(audioSource.time);

    }
}

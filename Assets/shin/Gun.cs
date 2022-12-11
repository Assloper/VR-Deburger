using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float bullet_speed = 5000;       // 탄속
    public float bullet_cooldown_Interval = 0.3f;    // 총알 쿨다운
    float timer_cooldown = 0;               // 쿨다운을 위한 타이머
    public bool Shoot()     // 외부에서는 public Gun Gun으로 참조 후, Gun.Shoot();으로 사용
    {
        //GameObject projectile = Instantiate(bullet, new Vector3(transform.position.x, 0, transform.position.z + 2), Quaternion.identity) as GameObject;
        //Physics.Raycast(ray, out hitInfo);



        if (timer_cooldown >= bullet_cooldown_Interval)
        {
            if (ARAVRInput.GetDown(ARAVRInput.Button.One) || Input.GetKey(KeyCode.Space))
            {

                GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject; // 생성과 동시에 좌표 및 방향 벡터정보를 이미 넘겨줌
                                                                                                                    //projectile.transform.position = hitInfo.point;                     // 이미 Instantiate에서 정의된 부분
                                                                                                                    //projectile.transform.position = this.transform.position;          //  위와 비슷한 내용
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * bullet_speed);
                Destroy(projectile, 2);
                timer_cooldown = 0;

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {

            return false;   // Shoot 실패의 경우 false return
        }
    }


    private void Update()
    {
        timer_cooldown += Time.deltaTime;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float bullet_speed = 5000;       // ź��
    public float bullet_cooldown_Interval = 0.3f;    // �Ѿ� ��ٿ�
    float timer_cooldown = 0;               // ��ٿ��� ���� Ÿ�̸�
    public bool Shoot()     // �ܺο����� public Gun Gun���� ���� ��, Gun.Shoot();���� ���
    {
        //GameObject projectile = Instantiate(bullet, new Vector3(transform.position.x, 0, transform.position.z + 2), Quaternion.identity) as GameObject;
        //Physics.Raycast(ray, out hitInfo);



        if (timer_cooldown >= bullet_cooldown_Interval)
        {
            if (ARAVRInput.GetDown(ARAVRInput.Button.One) || Input.GetKey(KeyCode.Space))
            {

                GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject; // ������ ���ÿ� ��ǥ �� ���� ���������� �̹� �Ѱ���
                                                                                                                    //projectile.transform.position = hitInfo.point;                     // �̹� Instantiate���� ���ǵ� �κ�
                                                                                                                    //projectile.transform.position = this.transform.position;          //  ���� ����� ����
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

            return false;   // Shoot ������ ��� false return
        }
    }


    private void Update()
    {
        timer_cooldown += Time.deltaTime;
    }

}

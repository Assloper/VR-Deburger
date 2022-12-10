using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class voxel : MonoBehaviour
{
    public float MeteoSpeed=1.0f;
    public Rigidbody rb;
    Vector3 destination = new Vector3(0, 0, 0);

    public GameObject changeObject;
    public AudioClip collectSound;

    public int ScoreNum = 1;
    MeteoScript collision_script;

    public Slider MeteoHPBar;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        collision_script = GameObject.Find("Earth").GetComponent<MeteoScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            Collect();
        }/*else if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Debug.Log("meteo detect bullet");
        }*/
        else if(collision.gameObject.CompareTag("bullet"))
        {
            if(ScoreNum == 1)
            {
                // score
                collision_script.ScoreSum(ScoreNum);
                // 운석 피 깎는거 필요
                MeteoHPBar.value -= 0.4f;
                if (MeteoHPBar.value <= 0.0)
                    Collect();
            }
            else if(ScoreNum == 2)
            {
                collision_script.ScoreSum(ScoreNum);
                MeteoHPBar.value -= 0.2f;
                if (MeteoHPBar.value <= 0.0)
                    Collect();
            }
            else if (ScoreNum == 3)
            {
                collision_script.ScoreSum(ScoreNum);
                MeteoHPBar.value -= 0.13f;
                if (MeteoHPBar.value <= 0.0)
                    Collect();
            }
            else if (ScoreNum == 4)
            {
                collision_script.ScoreSum(ScoreNum);
                MeteoHPBar.value -= 0.1f;
                if (MeteoHPBar.value <= 0.0)
                    Collect();
            }
            else if (ScoreNum == 5)
            {
                collision_script.ScoreSum(ScoreNum);
                MeteoHPBar.value -= 0.07f;
                if (MeteoHPBar.value <= 0.0)
                    Collect();
            }
            else if (ScoreNum == 6)
            {
                collision_script.ScoreSum(ScoreNum);
                MeteoHPBar.value -= 0.034f;
                if (MeteoHPBar.value <= 0.0)
                    Collect();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, destination, speed);
        Vector3 speed = new Vector3 (0, 0, 0);
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref speed, MeteoSpeed);
    }

    public void Collect()
    {
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Destroy(gameObject);

        GameObject voxel = Instantiate(changeObject);
        voxel.transform.position = this.gameObject.transform.position;
        Destroy(voxel, 1.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoScript : MonoBehaviour
{
    public float time = 1;
    public float distance = 5.0f;
    float createTime;
    float currentTime;
    //public GameObject voxelFactory;
    public Slider HealthBar;

    public int collision = 100;
    public int count = 0;

    public GameObject[] meteoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        createTime = time;
    }

    public void Sum(char heal)
    {
        if (heal == '-')
        {
            count++;
            collision -= 10;
        }
        else if (heal == '+')
            collision += 10;

    }
    public void Hpbar(char heal)
    {
        if (heal == '-')
            HealthBar.value -= 0.1f;
        else if (heal == '+')
            HealthBar.value += 0.1f;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Meteo"))
        {
            Sum('-');
            Hpbar('-');
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            int randomTexture = Random.Range(0, 5);
            GameObject voxel = Instantiate(meteoPrefab[randomTexture]);

            //GameObject voxel = Instantiate(voxelFactory);
            Vector3 position = voxel.transform.localPosition;
            int randomNum = Random.Range(1, 4);
            if (randomNum == 1)
            {
                position.x = distance;
                position.y = 0;
                position.z = Random.Range(-distance, distance);
            }
            else if (randomNum == 2)
            {
                position.x = -distance;
                position.y = 0;
                position.z = Random.Range(-distance, distance);
            }
            else if (randomNum == 3)
            {
                position.x = Random.Range(-distance, distance);
                position.y = 0;
                position.z = distance;
            }
            else if (randomNum == 4)
            {
                position.x = Random.Range(-distance, distance);
                position.y = 0;
                position.z = -distance;
            }
            voxel.transform.localPosition = position;

            currentTime = 0;

            createTime = time;

        }


    }
}

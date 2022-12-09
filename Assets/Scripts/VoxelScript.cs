using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelScript : MonoBehaviour
{
    public float time = 1;
    public float distance = 5.0f;
    float createTime;
    float currentTime;
    public GameObject voxelFactory;

    // Start is called before the first frame update
    void Start()
    {
        createTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject voxel = Instantiate(voxelFactory);
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

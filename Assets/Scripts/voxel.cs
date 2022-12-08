using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voxel : MonoBehaviour
{
    public float speed=1;
    public Rigidbody rb;
    Vector3 destination = new Vector3(0, 0, 0);

    public GameObject changeObject;
    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            Collect();
        }else if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Debug.Log("meteo detect bullet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed);
        //Vector3 speed = new Vector3 (0, 0, 0);
        //transform.position = Vector3.SmoothDamp(transform.position, destination, ref speed, 0.1f);
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

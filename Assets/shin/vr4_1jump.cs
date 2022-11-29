using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vr4_1jump : MonoBehaviour
{
    public Rigidbody rb;
    public float JumpForce;
    public bool IsJumping = false;
    //public GameObject gameObject;

    AudioSource audioSource;
    public AudioClip audioJump;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsJumping == false)
            {
                this.rb.AddForce(transform.up * this.JumpForce);
                
                IsJumping = true;

                this.audioSource.clip = audioJump;
                this.audioSource.Play();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJumping = false;
        }
/*        else  // �ش� else���� �ǵ���� �������� ����
        {
            IsJumping = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        jump();
    }
}

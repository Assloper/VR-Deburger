using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_move_object : MonoBehaviour
{
    public GameObject earth_hp;

    private void Start()
    {
        earth_hp = GameObject.Find("Canvas/Slider");
    }

    private void Update()
    {
        earth_hp.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 20.0f, 0));
    }
}
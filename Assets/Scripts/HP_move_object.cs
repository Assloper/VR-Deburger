using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_move_object : MonoBehaviour
{
    public GameObject earth_hp;
    public float setPosY = 0.8f;

    private void Start()
    {
        earth_hp = transform.Find("Canvas/MeteoHP").gameObject;
    }

    private void Update()
    {
        earth_hp.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, setPosY, 0));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScripts : MonoBehaviour
{
    TextMeshProUGUI statusText;
    MeteoScript collision_script;
    int hp;
    int collision_count;

    // Start is called before the first frame update
    void Start()
    {
        statusText = GetComponent<TextMeshProUGUI>();
        collision_script = GameObject.Find("Earth").GetComponent<MeteoScript>();

        hp = collision_script.collision;
        collision_count = collision_script.count;
        Status();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp != collision_script.collision)
        {
            hp = collision_script.collision;
            collision_count = collision_script.count;
            Status();

            if (hp == 0)
                Application.Quit();
        }
    }

    void Status()
    {
        statusText.text = "[Collision Count]:" + collision_count.ToString() + "\n[HP]:"+hp.ToString();
    }
}

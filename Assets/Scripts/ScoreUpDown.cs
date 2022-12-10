using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpDown : MonoBehaviour
{
    TextMeshProUGUI statusText;
    MeteoScript collision_script;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        statusText = GetComponent<TextMeshProUGUI>();
        collision_script = GameObject.Find("Earth").GetComponent<MeteoScript>();

        score = collision_script.score;
        Debug.Log(score);
        Status();
    }

    // Update is called once per frame
    void Update()
    {
        if ( score != collision_script.score)
        {
            score = collision_script.score;
            Status();
        }
    }

    void Status()
    {
        statusText.text = "[Score] : " + score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMainScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("main");
    }
}

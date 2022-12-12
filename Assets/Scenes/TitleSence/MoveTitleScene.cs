using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTitleScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GameTitle");
    }
}

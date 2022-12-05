using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSence : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Option");
    }
}

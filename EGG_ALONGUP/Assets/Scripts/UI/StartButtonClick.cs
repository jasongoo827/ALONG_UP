using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonClick : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Map_Tutorial");
    }
}

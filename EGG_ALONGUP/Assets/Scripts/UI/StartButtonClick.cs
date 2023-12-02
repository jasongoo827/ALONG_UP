using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartButtonClick : MonoBehaviour
{
    public void SceneChangetoMap()
    {
        SceneManager.LoadScene("Map");

    }
    public void SceneChangetoTutorial()
    {
        SceneManager.LoadScene("Map_Tutorial");
    }
}

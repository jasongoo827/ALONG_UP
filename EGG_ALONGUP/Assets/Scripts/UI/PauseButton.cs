using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseButton : MonoBehaviour
{
    bool isPause = false;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public Slider audioSlider;
    float vloume;
    public Text muteButtonText;

    public void pause()
    {
        if (!this.isPause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            this.isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            this.isPause = false;
        }
    }
    public void quit()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void mute()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        muteButtonText.text = AudioListener.volume == 0 ? "On" : "Off";

    }

    public void volume()
    {
        float sound = audioSlider.value;
        if (sound == -40f) audioMixer.SetFloat("BGM_1", -80);
        else audioMixer.SetFloat("BGM_1", sound);

    }
    private void Start()
    {
        // Initialize vloume (volume) based on the initial slider value
        vloume = audioSlider.value;
    }

}

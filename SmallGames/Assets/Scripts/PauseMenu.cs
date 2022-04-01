using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void Pause()
    {
        // Resume
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1;
            AudioManager.instance.Play("Button");
            AudioManager.instance.UnPauseSound("Music");
        }
        // Pause
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0;
            AudioManager.instance.Play("Button");
            AudioManager.instance.PauseSound("Music");
        }
    }
}

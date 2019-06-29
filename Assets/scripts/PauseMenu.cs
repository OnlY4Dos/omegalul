using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;
    public GameObject InputSettingsMenuUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        SettingsMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        InputSettingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}

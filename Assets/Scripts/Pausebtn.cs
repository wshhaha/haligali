using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausebtn : MonoBehaviour
{
    public bool pause=false;
    public GameObject blind;
    public GameObject menu;
    public AudioClip btnsound;

    public void Pause()
    {
        Effectsound.instance().Sfxplay(btnsound);
        pause = !pause;
        if (pause == true)
        {
            Time.timeScale = 0;
            blind.SetActive(true);
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            blind.SetActive(false);
            menu.SetActive(false);
        }
    }
    public void Restart()
    {
        Effectsound.instance().Sfxplay(btnsound);
        Application.LoadLevel(1);
    }
    public void Exit()
    {
        Effectsound.instance().Sfxplay(btnsound);
        Application.Quit();
    }
}
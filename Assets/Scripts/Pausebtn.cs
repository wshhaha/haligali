using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausebtn : MonoBehaviour
{
    public bool pause=false;
    public GameObject pausebg;

    public void Pause()
    {
        pause = !pause;
        if (pause == true)
        {
            Time.timeScale = 0;
            pausebg.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausebg.SetActive(false);
        }
    }
}
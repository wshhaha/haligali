using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singelbtn : MonoBehaviour 
{
    public GameObject singel;
    public GameObject multi;
    public bool singelon=false;
    public bool multilon = false;

    public void Callsingel()
    {
        singelon = !singelon;
        if (singelon == true)
        {
            singel.SetActive(true);
            PlayerPrefs.SetInt("ai0", 1);
            PlayerPrefs.SetInt("ai1", 1);
            PlayerPrefs.SetInt("ai2", 1);
        }
        else
        {
            singel.SetActive(false);
        }
    }
    public void Callmulti()
    {
        multilon = !multilon;
        if (multilon == true)
        {
            multi.SetActive(true);
            PlayerPrefs.SetInt("ai0", 1);
            PlayerPrefs.SetInt("ai1", 1);
            PlayerPrefs.SetInt("ai2", 1);
            PlayerPrefs.SetFloat("mintime", 0.1f);
            PlayerPrefs.SetFloat("maxtime", 1f);
        }
        else
        {
            multi.SetActive(false);
        }
    }
    public void Startgame()
    {
        Application.LoadLevel(1);
    }
    public void Exitgame()
    {
        Application.Quit();
    }
}

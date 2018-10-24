using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onoffsoundmusic : MonoBehaviour 
{
    public bool soundoff=false;
    public bool musicoff=false;
    public GameObject bgm;
    public GameObject effect;
    public UISprite mu;
    public UISprite so;

    void Start () 
	{
		
	}	
	void Update () 
	{
        if (musicoff == true)
        {
            bgm.GetComponent<AudioSource>().enabled = false;
            mu.spriteName = "musicoff";
        }
        else
        {
            bgm.GetComponent<AudioSource>().enabled = true;
            mu.spriteName = "music";
        }
        if (soundoff == true)
        {
            effect.GetComponent<AudioSource>().enabled = false;
            so.spriteName = "soundoff";
        }
        else
        {
            effect.GetComponent<AudioSource>().enabled = true;
            so.spriteName = "sound";
        }
    }
    public void Musicclick()
    {
        musicoff = !musicoff;        
    }
    public void Soundclick()
    {
        soundoff = !soundoff;        
    }
}
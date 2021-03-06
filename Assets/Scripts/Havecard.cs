﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Havecard : MonoBehaviour 
{
    public List<GameObject> remaincard;
    public UILabel victory;
    public GameObject counter;
    public GameObject build;
    public bool drag = false;
    public UILabel cardnum;
    public UILabel itemact;
    public bool useitem = false;
    public AudioClip vicsound;
    public AudioClip itemsound;
    public AudioClip dragsound;
    public bool oncesound = false;
    public GameObject bgm;
    public float degree;
    public GameObject itemmenu;
    public GameObject itemblind;
    public UILabel user;
    public UILabel target;
    public UILabel amount;

    void Start () 
	{
        int i = PlayerPrefs.GetInt("item");
        if (i == 1)
        {
            useitem = false;
        }
        else
        {
            useitem = true;
        }
	}
	
	void Update () 
	{
        cardnum.text = "\nCARD : " + remaincard.Count;
        if (useitem == false)
        {
            itemact.text = "ITEM : O\n";
        }
        else
        {
            itemact.text = "ITEM : X\n";
        }
        if (remaincard.Count == 60)
        {
            if (oncesound == false)
            {
                bgm.SetActive(false);
                oncesound = true;
                Effectsound.instance().Sfxplay(vicsound);
            }
            victory.text = gameObject.name + "\nVICTORY";
            counter.GetComponent<Fruitcounter>().endgame1 = true;            
            Endgame(true);
        }
        if (drag == true&&GetComponent<Yourturn>().turn==true)
        {
            degree += Time.deltaTime * 200;
            Dragcard();
        }
        else
        {
            degree = 0;
        }
	}    
    public void Pillageready()
    {
        if (useitem == false && GetComponent<Yourturn>().turn == true)
        {
            build.GetComponent<Builddeck>().Lockon();
            if (build.GetComponent<Builddeck>().target == gameObject || build.GetComponent<Builddeck>().target == null)
            {
                return;
            }
            itemblind.SetActive(true);
            itemmenu.SetActive(true);
            user.text = "USER : " + gameObject.name;
            target.text = "TARGET : " + build.GetComponent<Builddeck>().target.gameObject.name;
            amount.text = "CARD : " + build.GetComponent<Builddeck>().bestcollect / 2;
        }
    }
    public void Pilcancel()
    {
        itemblind.SetActive(false);
        itemmenu.SetActive(false);
    }
    public void Pillage()
    {
        Effectsound.instance().Sfxplay(itemsound);
        itemblind.SetActive(false);
        itemmenu.SetActive(false);
        StartCoroutine("Pillagemove");
        useitem = true;        
    }
    IEnumerator Pillagemove()
    {
        for (int i = 0; i < build.GetComponent<Builddeck>().bestcollect / 2; i++)
        {
            build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.parent = transform;
            build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.localRotation = Quaternion.Euler(0, 0, 0);            
            Vector3 ori = build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.localPosition;
            for (float j = 1; j > 0; j-=0.2f)
            {
                build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.localPosition = ori * j;
                yield return new WaitForEndOfFrame();
            }
            build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.localPosition = Vector3.zero;
            remaincard.Add(build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i]);
            build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard.Remove(build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i]);
        }        
    }
    public void Dragon()
    {
        Effectsound.instance().Sfxplay(dragsound);
        drag = true;     
    }
    public void Dragoff()
    {
        drag = false;
    }
    void Dragcard()
    {
        remaincard[0].GetComponent<UIPanel>().depth = counter.GetComponent<Fruitcounter>().opencard.Count;
        remaincard[0].transform.Translate(0, Time.deltaTime, 0);
        if (degree > 90)
        {
            degree = 90;
        }
        remaincard[0].GetComponentInChildren<UISprite>().transform.localRotation = Quaternion.Euler(-degree, 0, 0);
        if (remaincard[0].transform.localPosition.y >= 0.25f)
        {
            remaincard[0].transform.localPosition = new Vector3(0, 0.25f, 0);
        }
    }
    public void Nextgame()
    {
        if (PlayerPrefs.GetInt("singel") == 1)
        {
            GetComponent<Singelstage>().Nextstageset();
        }
        else
        {
            Adsmanager.instance().ShowRewardedAd();            
        }
    }
    public void Retry()
    {
        Adsmanager.instance().ShowRewardedAd();        
    }
    public void Returntotitlewin()
    {
        int i = PlayerPrefs.GetInt("unlock");
        i++;
        PlayerPrefs.SetInt("unlock", i);        
        Application.LoadLevel(0);        
    }
    public void Returntotitlelose()
    {        
        Application.LoadLevel(0);
    }
    public void Endgame(bool tf)
    {
        switch (gameObject.name)
        {
            case "1P":
                counter.GetComponent<Fruitcounter>().endgame[0] = tf;
                break;
            case "2P":
                counter.GetComponent<Fruitcounter>().endgame[1] = tf;
                break;
            case "3P":
                counter.GetComponent<Fruitcounter>().endgame[2] = tf;
                break;
            case "4P":
                counter.GetComponent<Fruitcounter>().endgame[3] = tf;
                break;
        }
    }
}
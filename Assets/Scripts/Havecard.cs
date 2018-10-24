using System.Collections;
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
    public bool useitem = false;
    public AudioClip vicsound;
    public AudioClip itemsound;
    public AudioClip dragsound;
    public bool oncesound = false;
    public GameObject bgm;

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
        cardnum.text = "CARD\n" + remaincard.Count;
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
            Dragcard();
        }
	}    
    public void Pillage()
    {
        if (useitem == false&&GetComponent<Yourturn>().turn==true)
        {
            build.GetComponent<Builddeck>().Lockon();
            if (build.GetComponent<Builddeck>().target == gameObject)
            {
                return;
            }
            Effectsound.instance().Sfxplay(itemsound);
            for (int i = 0; i < build.GetComponent<Builddeck>().bestcollect / 2; i++)
            {
                build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.parent = transform;
                build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.localRotation = Quaternion.Euler(0, 0, 0);
                build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i].transform.localPosition = Vector3.zero;
                remaincard.Add(build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i]);
                build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard.Remove(build.GetComponent<Builddeck>().target.GetComponent<Havecard>().remaincard[i]);
            }
        }
        useitem = true;
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
        if (remaincard[0].transform.localPosition.y >= 0.25f)
        {
            remaincard[0].transform.localPosition = new Vector3(0, 0.25f, 0);
        }
    }
    public void Nextgame()
    {
        Application.LoadLevel(1);
        //if (remaincard.Count == 0)
        //{
        //    return;
        //}
        //for (int i = 0; i < 4; i++)
        //{
        //    build.GetComponent<Builddeck>().pnum[i] = 0;
        //}
        //foreach (var item in remaincard)
        //{
        //    item.transform.rotation = Quaternion.Euler(0, 0, 0);
        //    item.transform.parent = build.transform;
        //    build.GetComponent<Builddeck>().deck.Add(item);
        //}
        //remaincard.Clear();
        //foreach (var item in build.GetComponent<Builddeck>().deck)
        //{
        //    build.GetComponent<Builddeck>().Seperatecard(item);
        //}
        //build.GetComponent<Builddeck>().deck.Clear();
        //counter.GetComponent<Fruitcounter>().endgame1 = false;
        //counter.GetComponent<Fruitcounter>().endround = false;
        //Endgame(false);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIscript : MonoBehaviour 
{
    public bool aion=false;
    public float reactiontime;
    public float cooltime;
    public float coolmax;
    public float coolmin;
    public GameObject counter;
    public float dragtime;
    public float dragcool;
    public float delay;
    public float delaycool;

	void Start () 
	{
        Aionoff();
        coolmin = PlayerPrefs.GetFloat("mintime");
        coolmax = PlayerPrefs.GetFloat("maxtime");
        Setcooltime();
        Setdragcool();
        delaycool = 0.2f;
    }	
	void Update () 
	{
        if (aion == true)
        {
            if (counter.GetComponent<Fruitcounter>().canwin == true)
            {
                Aibell();
            }
            else
            {
                AIreverse();
            }
        }
	}
    public void Aionoff()
    {
        switch (gameObject.name)
        {
            case "2P":
                int tf0 = PlayerPrefs.GetInt("ai0");
                if (tf0 == 1)
                {
                    aion = true;
                }
                else
                {
                    aion = false;
                }
                break;
            case "3P":
                int tf1 = PlayerPrefs.GetInt("ai1");
                if (tf1 == 1)
                {
                    aion = true;
                }
                else
                {
                    aion = false;
                }
                break;
            case "4P":
                int tf2 = PlayerPrefs.GetInt("ai2");
                if (tf2 == 1)
                {
                    aion = true;
                }
                else
                {
                    aion = false;
                }
                break;
        }
    }
    public void Aibell()
    {
        if (counter.GetComponent<Fruitcounter>().canwin == true)
        {
            reactiontime += Time.deltaTime;
            if (reactiontime >= cooltime)
            {
                GetComponent<Ringbell>().Ring();
                reactiontime = 0;
            }
        }
    }
    public void Setcooltime()
    {
        cooltime = Random.Range(coolmin, coolmax);        
    }
    public void Setdragcool()
    {
        dragcool = Random.Range(0, 0.4f);
    }
    public void AIreverse()
    {
        if (GetComponent<Yourturn>().turn == true&&counter.GetComponent<Fruitcounter>().endround==false)
        {
            delay += Time.deltaTime;
            if (delay > delaycool)
            {
                if (dragtime >= dragcool)
                {
                    GetComponent<Yourturn>().Turnon();
                    GetComponent<Havecard>().Dragoff();
                    dragtime = 0;
                    Setdragcool();
                    GetComponent<Reversecard>().check = true;
                    GetComponent<Reversecard>().Reversecardopen();
                    delay = 0;
                }
                else
                {
                    if (GetComponent<Havecard>().drag == false)
                    {
                        GetComponent<Havecard>().Dragon();
                    }
                    dragtime += Time.deltaTime;
                }                
            }
        }
    }
}
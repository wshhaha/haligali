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
                    GetComponent<Havecard>().Dragon();
                    dragtime += Time.deltaTime;
                }                
            }
        }
    }
}
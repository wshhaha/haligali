﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yourturn : MonoBehaviour 
{
    public bool turn;
    public bool lose = false;
    public GameObject counter;

	void Start () 
	{
        if (gameObject.name == "1P")
        {
            turn = true;
        }
	}
	
	void Update () 
	{
		if(counter.GetComponent<Fruitcounter>().endround == true&&GetComponent<Havecard>().remaincard.Count==0)
        {
            lose = true;
        }
        if (turn == true && lose == true)
        {
            switch (gameObject.name)
            {
                case "1P":
                    GetComponent<Ringbell>().p2.GetComponent<Yourturn>().Turnon();
                    break;
                case "2P":
                    GetComponent<Ringbell>().p3.GetComponent<Yourturn>().Turnon();
                    break;
                case "3P":
                    GetComponent<Ringbell>().p4.GetComponent<Yourturn>().Turnon();
                    break;
                case "4P":
                    GetComponent<Ringbell>().p1.GetComponent<Yourturn>().Turnon();
                    break;
            }
            turn = false;
        }
	}

    public void Turnon()
    {        
        turn = true;
    }
}

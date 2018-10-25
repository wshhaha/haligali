using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yourturn : MonoBehaviour 
{
    public bool turn;
    public bool lose = false;
    public GameObject counter;
    public GameObject nextplayer;

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
            Skipturn();
        }
        if (GetComponent<Havecard>().remaincard.Count == 0)
        {
            Skipturn();
        }
        if (gameObject.name == "1P" && lose == true)
        {
            counter.GetComponent<Fruitcounter>().singellose.SetActive(true);
        }
	}
    void Skipturn()
    {
        switch (gameObject.name)
        {
            case "1P":
                GetComponent<Ringbell>().p1.GetComponent<Yourturn>().Turnon();
                break;
            case "2P":
                GetComponent<Ringbell>().p2.GetComponent<Yourturn>().Turnon();
                break;
            case "3P":
                GetComponent<Ringbell>().p3.GetComponent<Yourturn>().Turnon();
                break;
            case "4P":
                GetComponent<Ringbell>().p4.GetComponent<Yourturn>().Turnon();
                break;
        }
        turn = false;
    }
    public void Turnon()
    {  
        if(turn==true)
        nextplayer.GetComponent<Yourturn>().turn = true;
    }
}

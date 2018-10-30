using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yourturn : MonoBehaviour 
{
    public bool turn;
    public bool lose = false;
    public GameObject counter;
    public GameObject nextplayer;
    public GameObject build;
    public float starttime;

	void Start () 
	{
        starttime = 0;
        if (gameObject.name == "1P")
        {
            turn = true;
        }
	}
	
	void Update () 
	{        
        starttime += Time.deltaTime;     
		if(counter.GetComponent<Fruitcounter>().endround == true&&GetComponent<Havecard>().remaincard.Count==0)
        {
            if (counter.GetComponent<Fruitcounter>().roundwinner == gameObject.name)
            {
                return;
            }
            lose = true;
        }
        if (turn == true && lose == true)
        {
            Skipturn();
        }
        if (GetComponent<Havecard>().remaincard.Count == 0 && starttime > 3)
        {
            print("1");
            if (build.GetComponent<Builddeck>().suffle == true)
            {
                return;
            }
            Skipturn();
        }
        if (gameObject.name == "1P" && lose == true && PlayerPrefs.GetInt("singel") == 1)
        {
            counter.GetComponent<Fruitcounter>().singellose.SetActive(true);
        }
        if (turn == true && PlayerPrefs.GetInt("singel") == 0)
        {
            Stageinfo.instance().GetComponent<UILabel>().text = gameObject.name + "\nTurn";
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

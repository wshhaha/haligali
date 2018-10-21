using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ringbell : MonoBehaviour 
{    
    public GameObject counter;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public List<GameObject> p;
    public int remain;
    public UILabel winner;

    void Start()
    {
        Setplayer();        
    }
    void Taketurn(int num)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == num)
            {
                GetComponent<Ringbell>().p[i].GetComponent<Yourturn>().Turnon();
            }
            else
            {
                GetComponent<Ringbell>().p[i].GetComponent<Yourturn>().turn = false;
            }
        }
    }
    void Setplayer()
    {
        p1 = GameObject.Find("1P");
        p2 = GameObject.Find("2P");
        p3 = GameObject.Find("3P");
        p4 = GameObject.Find("4P");
        p = new List<GameObject>();
        p.Add(p1);
        p.Add(p2);
        p.Add(p3);
        p.Add(p4);
        p.Add(p1);
        p.Add(p2);
        p.Add(p3);
        p.Add(p4);
    }
    void Giveother(int num)
    {
        if (p[(num + 1)].GetComponent<Yourturn>().lose == false)
        {
            GetComponent<Havecard>().remaincard[num].transform.parent = p[(num + 1)].transform;
            GetComponent<Havecard>().remaincard[num].transform.localPosition = Vector3.zero;
            GetComponent<Havecard>().remaincard[num].transform.localRotation = Quaternion.Euler(0, 0, 0);
            p[(num + 1)].GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[num]);
        }
    }
    void Penelity(int num, int need)
    {        
        for (int i = 0; i < need; i++)
        {
            Giveother(i + num);
        }        
        GetComponent<Havecard>().remaincard.RemoveRange(0, need);
    }
    public void Ring()
    {
        if (GetComponent<Yourturn>().lose == true)
        {
            return;
        }
        if (counter.GetComponent<Fruitcounter>().canwin == true)
        {
            counter.GetComponent<Fruitcounter>().endround = true;
            winner.text = "ROUND\nWINNER\n" + gameObject.name;
            switch (gameObject.name)
            {
                case "1P":
                    Taketurn(0);
                    break;
                case "2P":
                    Taketurn(1);
                    break;
                case "3P":
                    Taketurn(2);
                    break;
                case "4P":
                    Taketurn(3);
                    break;
            }
            foreach (var item in counter.GetComponent<Fruitcounter>().opencard)
            {
                item.transform.parent = transform;
                item.GetComponent<UIPanel>().depth = 0;
                GetComponent<Havecard>().remaincard.Add(item);
                item.transform.localPosition = Vector3.zero;
                item.transform.localRotation = Quaternion.Euler(0, 0, 0);                
            }
            counter.GetComponent<Fruitcounter>().opencard.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    counter.GetComponent<Fruitcounter>().num[i][j] = 0;
                }   
            }
        }
        if(counter.GetComponent<Fruitcounter>().canwin ==false && counter.GetComponent<Fruitcounter>().endround == false)
        {
            if (GetComponent<Havecard>().remaincard.Count <= 2)
            {
                switch (gameObject.name)
                {
                    case "1P":
                        Penelity(0, GetComponent<Havecard>().remaincard.Count);
                        break;
                    case "2P":
                        Penelity(1, GetComponent<Havecard>().remaincard.Count);
                        break;
                    case "3P":
                        Penelity(2, GetComponent<Havecard>().remaincard.Count);
                        break;
                    case "4P":
                        Penelity(3, GetComponent<Havecard>().remaincard.Count);
                        break;
                }
            }
            else
            {
                switch (gameObject.name)
                {
                    case "1P":
                        Penelity(0,3);
                        break;
                    case "2P":
                        Penelity(1,3);
                        break;
                    case "3P":
                        Penelity(2,3);
                        break;
                    case "4P":
                        Penelity(3,3);
                        break;
                }
            }
            
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reversecard : MonoBehaviour 
{
    public bool check=false;
    public GameObject counter;
    public int cardnum;
    public Fruitcounter card;

	void Start () 
	{
        card = counter.GetComponent<Fruitcounter>();
    }
	
	void Update () 
	{
        if (GetComponent<Havecard>().remaincard.Count != 0)
        {
            cardnum = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
        }
        if (check == true&&GetComponent<Yourturn>().turn==true&&card.endround==false)
        {
            if (GetComponent<Havecard>().remaincard.Count == 0)
            {
                check = false;
                GetComponent<Yourturn>().turn = false;
                return;
            }
            switch (gameObject.name)
            {
                case "1P":
                    Change(0);
                    break;
                case "2P":
                    Change(1);
                    break;
                case "3P":
                    Change(2);
                    break;
                case "4P":
                    Change(3);
                    break;
            }
            check = false;
            GetComponent<Yourturn>().turn = false;
        }
        else
        {
            check = false;
        }
	}    
    void Change(int j)
    {
        Changecolor(j);
        Movecard();
        GetComponent<Havecard>().remaincard.RemoveAt(0);        
    }
    void Changecolor(int j)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == j)
            {
                card.num[i][j] = cardnum;
            }
            else
            {
                card.num[i][j] = 0;
            }
        }
    }
    void Movecard()
    {
        GetComponent<Havecard>().remaincard[0].transform.localPosition = new Vector3(0, 0.25f, 0);
        GetComponent<Havecard>().remaincard[0].transform.Rotate(180, 0, 0);
        GetComponent<Havecard>().remaincard[0].transform.parent = counter.transform;
        counter.GetComponent<Fruitcounter>().opencard.Add(GetComponent<Havecard>().remaincard[0]);
    }
    public void Pushbtn()
    {
        check = true;
    }
}
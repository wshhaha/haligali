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
        cardnum= GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
        if (check == true&&GetComponent<Yourturn>().turn==true)
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
        switch (GetComponent<Havecard>().remaincard[0].tag)
        {
            case "red":
                Changered(j);
                break;
            case "yellow":
                Changeyellow(j);
                break;
            case "green":
                Changegreen(j);
                break;
            case "violet":
                Changeviolet(j);
                break;
        }
        Movecard();
        GetComponent<Havecard>().remaincard.RemoveAt(0);        
    }
    void Changered(int j)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                card.num[i][j] = cardnum;
            }
            else
            {
                card.num[i][j] = 0;
            }
        }
    }
    void Changeyellow(int j)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 1)
            {
                card.num[i][j] = cardnum;
            }
            else
            {
                card.num[i][j] = 0;
            }
        }
    }
    void Changegreen(int j)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 2)
            {
                card.num[i][j] = cardnum;
            }
            else
            {
                card.num[i][j] = 0;
            }
        }
    }
    void Changeviolet(int j)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 3)
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
        GetComponent<Havecard>().remaincard[0].transform.localPosition = new Vector3(0, 1.5f, 0);
        GetComponent<Havecard>().remaincard[0].transform.Rotate(180, 0, 0);
        GetComponent<Havecard>().remaincard[0].transform.parent = counter.transform;
        counter.GetComponent<Fruitcounter>().opencard.Add(GetComponent<Havecard>().remaincard[0]);
    }
    public void Pushbtn()
    {
        check = true;
    }
}
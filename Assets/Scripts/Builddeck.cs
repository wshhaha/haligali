using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builddeck : MonoBehaviour 
{
    public GameObject card;
    public int redlmt;
    public int yellowlmt;
    public int greenlmt;
    public int violetlmt;    
    int ronef;
    int rtwof;
    int rthreef;
    int rfourf;
    int rfivef;
    int yonef;
    int ytwof;
    int ythreef;
    int yfourf;
    int yfivef;
    int gonef;
    int gtwof;
    int gthreef;
    int gfourf;
    int gfivef;
    int vonef;
    int vtwof;
    int vthreef;
    int vfourf;
    int vfivef;
    int rj;
    int yj;
    int gj;
    int vj;
    public GameObject p1;    
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    int p1num;
    int p2num;
    int p3num;
    int p4num;

    void Start () 
	{
        Suffledeck();
	}
	void Suffledeck()
    {
        for (int i = 0; i < 60; i++)
        {
            GameObject deck = Instantiate(card);
            deck.transform.parent = transform;
            Selectfruit(deck);
            Givenum(deck);
            Seperatecard(deck);
            deck.name = deck.tag + deck.GetComponent<Cardstat>().numfruit;
        }
    }
    void Seperatecard(GameObject obj1)
    {
        int who = Random.Range(0, 4);
        switch (who)
        {
            case 0:
                if (p1num >14)
                {
                    Seperatecard(obj1);
                }
                else
                {
                    obj1.transform.parent = p1.transform;
                    obj1.transform.localPosition = Vector3.zero;
                    p1.GetComponent<Havecard>().remaincard.Add(obj1);
                    p1num++;
                }
                break;
            case 1:
                if (p2num >14)
                {
                    Seperatecard(obj1);
                }
                else
                {
                    obj1.transform.parent = p2.transform;
                    obj1.transform.localPosition = Vector3.zero;
                    p2.GetComponent<Havecard>().remaincard.Add(obj1);
                    obj1.transform.Rotate(0, 0, -90);
                    p2num++;
                }
                break;
            case 2:
                if (p3num >14)
                {
                    Seperatecard(obj1);
                }
                else
                {
                    obj1.transform.parent = p3.transform;
                    obj1.transform.localPosition = Vector3.zero;
                    p3.GetComponent<Havecard>().remaincard.Add(obj1);
                    p3num++;
                }
                break;
            case 3:
                if (p4num >14)
                {
                    Seperatecard(obj1);
                }
                else
                {
                    obj1.transform.parent = p4.transform;
                    obj1.transform.localPosition = Vector3.zero;
                    p4.GetComponent<Havecard>().remaincard.Add(obj1);
                    obj1.transform.Rotate(0, 0, 90);
                    p4num++;
                }
                break;
        }
    }
    void Givered(GameObject obj)
    {
        obj.transform.tag = "red";
        redlmt++;        
    }
    void Giveyellow(GameObject obj)
    {
        obj.transform.tag = "yellow";
        yellowlmt++;
    }
    void Givegreen(GameObject obj)
    {
        obj.transform.tag = "green";
        greenlmt++;
    }
    void Giveviolet(GameObject obj)
    {
        obj.transform.tag = "violet";
        violetlmt++;
    }
    
    void Givenum(GameObject obj)
    {
        int num = Random.Range(1, 7);        
        switch (obj.transform.tag)
        {
            case "red":
                switch (num)
                {
                    case 1:
                        if (ronef >= 5)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            ronef++;
                        }
                        break;
                    case 2:
                        if (rtwof >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            rtwof++;
                        }
                        break;
                    case 3:
                        if (rthreef >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            rthreef++;
                        }
                        break;
                    case 4:
                        if (rfourf >= 2)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            rfourf++;
                        }
                        break;
                    case 5:
                        if (rfivef >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            rfivef++;
                        }
                        break;
                    case 6:
                        if (rj >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            rj++;
                        }
                        break;
                }
                break;
            case "yellow":
                switch (num)
                {
                    case 1:
                        if (yonef >= 5)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            yonef++;
                        }
                        break;
                    case 2:
                        if (ytwof >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            ytwof++;
                        }
                        break;
                    case 3:
                        if (ythreef >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            ythreef++;
                        }
                        break;
                    case 4:
                        if (yfourf >= 2)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            yfourf++;
                        }
                        break;
                    case 5:
                        if (yfivef >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            yfivef++;
                        }
                        break;
                    case 6:
                        if (yj >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            yj++;
                        }
                        break;
                }
                break;
            case "green":
                switch (num)
                {
                    case 1:
                        if (gonef >= 5)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            gonef++;
                        }
                        break;
                    case 2:
                        if (gtwof >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            gtwof++;
                        }
                        break;
                    case 3:
                        if (gthreef >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            gthreef++;
                        }
                        break;
                    case 4:
                        if (gfourf >= 2)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            gfourf++;
                        }
                        break;
                    case 5:
                        if (gfivef >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            gfivef++;
                        }
                        break;
                    case 6:
                        if (gj >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            gj++;
                        }
                        break;
                }
                break;
            case "violet":
                switch (num)
                {
                    case 1:
                        if (vonef >= 5)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            vonef++;
                        }
                        break;
                    case 2:
                        if (vtwof >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            vtwof++;
                        }
                        break;
                    case 3:
                        if (vthreef >= 3)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            vthreef++;
                        }
                        break;
                    case 4:
                        if (vfourf >= 2)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            vfourf++;
                        }
                        break;
                    case 5:
                        if (vfivef >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            vfivef++;
                        }
                        break;
                    case 6:
                        if (vj >= 1)
                        {
                            Givenum(obj);
                        }
                        else
                        {
                            obj.GetComponent<Cardstat>().numfruit = num;
                            vj++;
                        }
                        break;
                }
                break;
        }
    }

    void Selectfruit(GameObject obj)
    {
        int num = Random.Range(0, 4);
        switch (num)
        {
            case 0:
                if (redlmt >= 15)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Givered(obj);
                }
                break;
            case 1:
                if (yellowlmt >= 15)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Giveyellow(obj);
                }
                break;
            case 2:
                if (greenlmt >= 15)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Givegreen(obj);
                }
                break;
            case 3:
                if (violetlmt >= 15)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Giveviolet(obj);
                }
                break;
        }
    }
}
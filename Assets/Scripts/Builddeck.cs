using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builddeck : MonoBehaviour 
{
    public GameObject card;
    public List<GameObject> deck;
    public List<int> rnum;
    public List<int> ynum;
    public List<int> gnum;
    public List<int> vnum;
    public List<List<int>> num;
    public GameObject p1;    
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public List<GameObject> p;    
    public List<int> pnum;
    public List<string> cc;
    public List<int> limits;
    public int bestcollect;
    public GameObject target;
    public int who;    

    void Start () 
	{
        Time.timeScale = 1;
        Colornumreset();
        Playerreset();
        CardColor();        
        StartCoroutine("Createdeck");        
    }
    
    public void Resetitem()
    {
        for (int i = 0; i < 4; i++)
        {
            p[i].GetComponent<Havecard>().useitem = false;
        }
    }
    public void Lockon()
    {
        for (int i = 0; i < 4; i++)
        {
            if (p[i].GetComponent<Havecard>().remaincard.Count > 15)
            {
                bestcollect = p[i].GetComponent<Havecard>().remaincard.Count;
                target = p[i];
            }
        }
    }
    void CardColor()
    {
        cc = new List<string>();
        cc.Add("red");
        cc.Add("yellow");
        cc.Add("green");
        cc.Add("violet");
        limits = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            limits.Add(0);
        }
    }
    void Playerreset()
    {
        p = new List<GameObject>();
        p.Add(p1);
        p.Add(p2);
        p.Add(p3);
        p.Add(p4);
        pnum = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            pnum.Add(0);            
        }
    }
    void Colornumreset()
    {
        rnum = new List<int>();
        ynum = new List<int>();
        gnum = new List<int>();
        vnum = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            rnum.Add(0);
            ynum.Add(0);
            gnum.Add(0);
            vnum.Add(0);
        }
        num = new List<List<int>>();
        num.Add(rnum);
        num.Add(ynum);
        num.Add(gnum);
        num.Add(vnum);
    }
 	IEnumerator Createdeck()
    {
        int i = 0;
        while (i<60)
        {
            GameObject deck = Instantiate(card);            
            deck.transform.parent = transform;
            deck.transform.localScale = new Vector3(0.0015f, 0.0015f, 0.0015f);
            Selectfruit(deck);
            Givenum(deck);
            Seperatecard(deck);
            deck.name = deck.tag + deck.GetComponent<Cardstat>().numfruit;
            i++;
            yield return new WaitForEndOfFrame();
        }       
    }
    public void Seperatecard(GameObject obj1)
    {
        who = Random.Range(0, 4);
        switch (who)
        {
            case 0:
                Createcard(obj1, who);
                break;
            case 1:
                Createcard(obj1, who);
                break;
            case 2:
                Createcard(obj1, who);
                break;
            case 3:
                Createcard(obj1, who);
                break;
        }
    }
    IEnumerator Gotoplayer(GameObject newcard)
    {        
        Vector3 ori = newcard.transform.localPosition;
        float factor=1;
        while (factor>0)
        {
            newcard.transform.localPosition = ori * factor;
            factor -= 0.1f;
            yield return new WaitForEndOfFrame();
        }
        newcard.transform.localPosition = Vector3.zero;        
    }
    public void Createcard(GameObject card, int pn)
    {
        if (pnum[pn] > 14)
        {
            Seperatecard(card);
        }
        else
        {            
            card.transform.parent = p[pn].transform;
            //card.transform.localPosition *= 0;
            StartCoroutine("Gotoplayer",card);
            p[pn].GetComponent<Havecard>().remaincard.Add(card);
            pnum[pn]++;
            if (pn == 1)
            {
                card.transform.Rotate(0, 0, -90);
            }
            if (pn == 2)
            {
                card.transform.Rotate(0, 0, -180);
            }
            if (pn == 3)
            {
                card.transform.Rotate(0, 0, 90);
            }
        }
    }
    void Givecolor(GameObject obj, int color)
    {
        if (limits[color] >= 15)
        {
            Selectfruit(obj);
        }
        else
        {
            obj.transform.tag = cc[color];
            limits[color]++;
        }        
    }
    void Rannum(GameObject obj,int color, int number)
    {
        switch (number)
        {
            case 0:
                if (num[color][number] >= 5)
                {
                    Givenum(obj);
                }
                else
                {
                    obj.GetComponent<Cardstat>().numfruit = (number+1);
                    num[color][number]++;
                }
                break;
            case 1:
                if (num[color][number] >= 3)
                {
                    Givenum(obj);
                }
                else
                {
                    obj.GetComponent<Cardstat>().numfruit = (number + 1);
                    num[color][number]++;
                }
                break;
            case 2:
                if (num[color][number] >= 3)
                {
                    Givenum(obj);
                }
                else
                {
                    obj.GetComponent<Cardstat>().numfruit = (number + 1);
                    num[color][number]++;
                }
                break;
            case 3:
                if (num[color][number] >= 2)
                {
                    Givenum(obj);
                }
                else
                {
                    obj.GetComponent<Cardstat>().numfruit = (number + 1);
                    num[color][number]++;
                }
                break;
            case 4:
                if (num[color][number] >= 1)
                {
                    Givenum(obj);
                }
                else
                {
                    obj.GetComponent<Cardstat>().numfruit = (number + 1);
                    num[color][number]++;
                }
                break;
            case 5:
                if (num[color][number] >= 1)
                {
                    Givenum(obj);
                }
                else
                {
                    obj.GetComponent<Cardstat>().numfruit = (number + 1);
                    num[color][number]++;
                }
                break;
        }
    }
    void Givenum(GameObject obj)
    {
        int num = Random.Range(0, 6);
        
        switch (obj.transform.tag)
        {
            case "red":
                Rannum(obj, 0, num);
                break;
            case "yellow":
                Rannum(obj, 1, num);
                break;
            case "green":
                Rannum(obj, 2, num);
                break;
            case "violet":
                Rannum(obj, 3, num);
                break;
        }
    }
    void Selectfruit(GameObject obj)
    {
        int num = Random.Range(0, 4);
        Givecolor(obj, num);
    }
}
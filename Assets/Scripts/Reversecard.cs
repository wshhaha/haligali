using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reversecard : MonoBehaviour 
{
    public bool check=false;
    public GameObject counter;
    public int cardnum;
    public Fruitcounter card;
    public AudioClip reversesound;
    public GameObject reverseeffect;
    public GameObject eftmanager;

	void Start () 
	{
        card = counter.GetComponent<Fruitcounter>();
    }
	
	void Update () 
	{
        Reversecardopen();
    }    
    public void Reversecardopen()
    {
        if (GetComponent<Havecard>().remaincard.Count != 0)
        {
            cardnum = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
        }
        if (check == true && GetComponent<Yourturn>().turn == true && card.endround == false)
        {
            if (GetComponent<Havecard>().remaincard.Count == 0)
            {
                check = false;
                GetComponent<Yourturn>().turn = false;
                return;
            }
            Effectsound.instance().Sfxplay(reversesound);
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
            GameObject eft = Instantiate(reverseeffect);
            eft.transform.parent = eftmanager.transform;
            eft.transform.localPosition = Vector3.zero;
            eft.transform.localScale *= 2;
            check = false;
            GetComponent<Yourturn>().turn = false;
        }
        else
        {
            check = false;
        }
        Remainone();
    }
    void Remainone()
    {
        if (GetComponent<Havecard>().remaincard.Count == 1)
        {
            GetComponent<Havecard>().remaincard[0].GetComponentInChildren<UISprite>().spriteName = "back1";
        }
        else
        {
            foreach (var item in GetComponent<Havecard>().remaincard)
            {
                item.GetComponentInChildren<UISprite>().spriteName = "back";
            }            
        }
    }
    void Change(int j)
    {
        Changecolor(j);
        Movecard();
        GetComponent<Havecard>().remaincard.RemoveAt(0);        
    }
    void Replacenum(int num,int j)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == num)
            {
                card.num[i][j] = cardnum;
            }
            else
            {
                card.num[i][j] = 0;
            }
        }
    }
    void Changecolor(int j)
    {
        switch (GetComponent<Havecard>().remaincard[0].tag)
        {
            case "red":
                Replacenum(0, j);
                break;
            case "yellow":
                Replacenum(1, j);
                break;
            case "green":
                Replacenum(2, j);
                break;
            case "violet":
                Replacenum(3, j);
                break;
        }
    }
    void Movecard()
    {        
        GetComponent<Havecard>().remaincard[0].GetComponent<UIPanel>().depth = counter.GetComponent<Fruitcounter>().opencard.Count;
        GetComponent<Havecard>().remaincard[0].transform.localPosition = new Vector3(0, 0.25f, 0);
        GetComponent<Havecard>().remaincard[0].transform.Rotate(180, 0, 0);
        GetComponent<Havecard>().remaincard[0].GetComponentInChildren<UISprite>().transform.localRotation = Quaternion.Euler(0, 0, 0);
        GetComponent<Havecard>().remaincard[0].transform.parent = counter.transform;
        counter.GetComponent<Fruitcounter>().opencard.Add(GetComponent<Havecard>().remaincard[0]);
    }
    public void Pushbtn()
    {
        check = true;
    }
}
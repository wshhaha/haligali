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
    public int jokerlmt;
    int onef = 5;
    int twof = 3;
    int threef = 3;
    void Start () 
	{
        for (int i = 0; i < 60; i++)
        {
            GameObject deck = Instantiate(card);
            deck.transform.parent = transform;            
            Selectfruit(deck);
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
    void Givejoker(GameObject obj)
    {
        obj.transform.tag = "joker";
        jokerlmt++;
    }
    void Selectfruit(GameObject obj)
    {
        int num = Random.Range(0, 5);
        switch (num)
        {
            case 0:
                if (redlmt >= 14)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Givered(obj);
                }
                break;
            case 1:
                if (yellowlmt >= 14)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Giveyellow(obj);
                }
                break;
            case 2:
                if (greenlmt >= 14)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Givegreen(obj);
                }
                break;
            case 3:
                if (violetlmt >= 14)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Giveviolet(obj);
                }
                break;
            case 4:
                if (jokerlmt >= 4)
                {
                    Selectfruit(obj);
                }
                else
                {
                    Givejoker(obj);
                }
                break;
        }
    }
}
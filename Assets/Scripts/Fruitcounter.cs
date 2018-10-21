using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitcounter : MonoBehaviour 
{
    public bool canwin=false;
    public bool endround = false;    
    public int rednum;
    public int yellownum;
    public int greennum;
    public int violetnum;
    public List<GameObject> opencard;
    public List<int> rnum;
    public List<int> ynum;
    public List<int> gnum;
    public List<int> vnum;
    public List<List<int>> num;
    public GameObject next;

    void Start () 
	{
        rnum = new List<int>();
        ynum = new List<int>();
        gnum = new List<int>();
        vnum = new List<int>();
        for (int i = 0; i < 4; i++)
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
	
	void Update () 
	{
        if (endround == true)
        {
            next.SetActive(true);
        }
        else
        {
            next.SetActive(false);
        }
        rednum = rnum[0] + rnum[1] + rnum[2] + rnum[3];
        yellownum = ynum[0] + ynum[1] + ynum[2] + ynum[3];
        greennum = gnum[0] + gnum[1] + gnum[2] + gnum[3];
        violetnum = vnum[0] + vnum[1] + vnum[2] + vnum[3];
        if (rednum==5|| yellownum == 5 || greennum == 5 || violetnum == 5)
        {
            canwin = true;
        }
        else
        {
            canwin = false;
        }
	}   
    
    public void Nextround()
    {
        endround = false;
    }
}
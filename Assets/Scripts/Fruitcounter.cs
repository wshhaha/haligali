﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitcounter : MonoBehaviour 
{
    public bool canwin=false;
    public bool endround = false;
    public List<bool> endgame;
    public bool endgame1;
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
    public List<GameObject> victory;
    public GameObject Build;

    void Start () 
	{
        for (int i = 0; i < 4; i++)
        {
            endgame.Add(false);            
        }
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
        if (endgame1 == true)
        {
            for (int i = 0; i < 4; i++)
            {
                if (endgame[i] == true)
                {
                    victory[i].SetActive(true);
                }                
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                victory[i].SetActive(false);
            }
        }
        if (endround == true&&endgame1==false)
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
        if (opencard.Count == 60 && canwin == false)
        {            
            for (int i = 0; i < 4; i++)
            {
                Build.GetComponent<Builddeck>().pnum[i] = 0;
            }
            foreach (var item in opencard)
            {
                item.transform.rotation = Quaternion.Euler(0, 0, 0);
                Build.GetComponent<Builddeck>().Seperatecard(item);
            }            
            opencard.Clear();
        }
	}   
    
    public void Nextround()
    {
        endround = false;
    }
}
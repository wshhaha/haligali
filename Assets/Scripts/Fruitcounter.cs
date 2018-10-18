using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitcounter : MonoBehaviour 
{
    public bool canwin=false;
    public int rednum;
    public int yellownum;
    public int greennum;
    public int violetnum;
    public List<GameObject> opencard;
    public int p1r;
    public int p1y;
    public int p1g;
    public int p1v;
    public int p2r;
    public int p2y;
    public int p2g;
    public int p2v;
    public int p3r;
    public int p3y;
    public int p3g;
    public int p3v;
    public int p4r;
    public int p4y;
    public int p4g;
    public int p4v;

    void Start () 
	{
		
	}
	
	void Update () 
	{
        rednum = p1r + p2r + p3r + p4r;
        yellownum = p1y + p2y + p3y + p4y;
        greennum = p1g + p2g + p3g + p4g;
        violetnum = p1v + p2v + p3v + p4v;
        if (rednum==5|| yellownum == 5 || greennum == 5 || violetnum == 5)
        {
            canwin = true;
        }
        else
        {
            canwin = false;
        }
	}
}

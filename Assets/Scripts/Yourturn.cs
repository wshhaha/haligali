using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yourturn : MonoBehaviour 
{
    public bool turn;

	void Start () 
	{
        if (gameObject.name == "1P")
        {
            turn = true;
        }
	}
	
	void Update () 
	{
		
	}

    public void Turnon()
    {
        turn = true;
    }
}

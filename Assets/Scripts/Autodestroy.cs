using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour 
{
	void Start () 
	{
		
	}	
	void Update () 
	{
        Destroy(gameObject, 1);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagelvl : MonoBehaviour 
{
	void Start () 
	{
        GetComponent<UILabel>().text = transform.parent.gameObject.name;
	}	
	void Update () 
	{
		
	}    
}

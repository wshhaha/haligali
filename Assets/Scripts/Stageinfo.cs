using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stageinfo : MonoBehaviour 
{
	void Start () 
	{
        GetComponent<UILabel>().text = PlayerPrefs.GetString("stage");
	}	
	void Update () 
	{
		
	}
}

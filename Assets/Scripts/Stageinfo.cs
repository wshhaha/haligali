using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stageinfo : MonoBehaviour 
{
    static Stageinfo _instance;
    public static Stageinfo instance()
    {
        return _instance;
    }
	void Start () 
	{
        if (_instance == null)
        {
            _instance = this;
        }
        GetComponent<UILabel>().text = PlayerPrefs.GetString("stage");
	}	
	void Update () 
	{
        
	}
}

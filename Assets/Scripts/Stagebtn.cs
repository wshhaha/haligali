﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagebtn : MonoBehaviour 
{
    public GameObject stagebtn;
    public GameObject singel;
    
	void Start () 
	{
        Time.timeScale = 0;
        for (int i = 0; i < 30; i++)
        {
            GameObject btn=Instantiate(stagebtn);
            btn.name = (i + 1) + "";
            btn.GetComponent<Stagebtninfo>().stnum = (i + 1);
            btn.transform.parent = transform;
            btn.transform.localScale = new Vector3(1, 1, 1);
        }
        GetComponent<UIGrid>().enabled = true;
        singel.transform.localPosition = Vector3.zero;
        singel.SetActive(false);
    }		
}

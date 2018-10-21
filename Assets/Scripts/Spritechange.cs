using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spritechange : MonoBehaviour
{    
	void Start ()
    {        
        GetComponent<UISprite>().spriteName = "back";
	}
	void Update ()
    {
        if (transform.parent.transform.parent.name== "Fruitcounter")
        {
            GetComponent<UISprite>().spriteName = transform.parent.name;
        }        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockbtn : MonoBehaviour 
{
    public GameObject player;
    public string ori;
    public string lose;

	void Start () 
	{
        ori = GetComponent<UISprite>().spriteName;
	}	
	void Update () 
	{
        if (player.GetComponent<Yourturn>().lose == true)
        {
            GetComponent<UISprite>().spriteName = lose;
            if (gameObject.name == "Reverse")
            {
                GetComponentInChildren<UILabel>().text = "";
            }
        }
        else
        {
            GetComponent<UISprite>().spriteName = ori;
            if (gameObject.name == "Reverse")
            {
                GetComponentInChildren<UILabel>().text = "REVERSE";
            }
        }
	}
}

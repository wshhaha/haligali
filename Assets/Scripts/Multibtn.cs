using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multibtn : MonoBehaviour 
{
    public bool p2 = false;
    public bool p3 = false;
    public bool p4 = false;
    public bool tem = false;
    public GameObject pp2;
    public GameObject pp3;
    public GameObject pp4;
    public GameObject item;

    void Start () 
	{
		
	}	
	void Update () 
	{
        if (p2 == true)
        {
            pp2.GetComponent<UISprite>().spriteName = "Button_43";
        }
        else
        {
            pp2.GetComponent<UISprite>().spriteName = "Button_34";
        }
        if (p3 == true)
        {            
            pp3.GetComponent<UISprite>().spriteName = "Button_42";
        }
        else
        {         
            pp3.GetComponent<UISprite>().spriteName = "Button_33";
        }
        if (tem == true)
        {
            item.GetComponent<UISprite>().spriteName = "Button_42";
        }
        else
        {
            item.GetComponent<UISprite>().spriteName = "Button_33";
        }
        if (p4 == true)
        {            
            pp4.GetComponent<UISprite>().spriteName = "Button_45";
        }
        else
        {            
            pp4.GetComponent<UISprite>().spriteName = "Button_36";
        }
    }
    public void Setitem()
    {
        tem = !tem;
        if (tem == true)
        {
            PlayerPrefs.SetInt("item", 1);
        }
        else
        {
            PlayerPrefs.SetInt("item", 0);
        }
    }
    public void Setplayer(GameObject p)
    {
        switch (p.name)
        {
            case "2P":
                p2 = !p2;
                if (p2 == true)
                {
                    PlayerPrefs.SetInt("ai0", 0);                    
                }
                else
                {
                    PlayerPrefs.SetInt("ai0", 1);                    
                }
                break;
            case "3P":
                p3 = !p3;
                if (p3 == true)
                {
                    PlayerPrefs.SetInt("ai1", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("ai1", 1);
                }
                break;
            case "4P":
                p4 = !p4;
                if (p4 == true)
                {
                    PlayerPrefs.SetInt("ai2", 0);                    
                }
                else
                {
                    PlayerPrefs.SetInt("ai2", 1);
                }
                break;
        }
    }
}

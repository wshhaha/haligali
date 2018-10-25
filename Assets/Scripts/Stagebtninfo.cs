using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagebtninfo : MonoBehaviour 
{
    public int stnum;
    public int unlock;
    public string origin;
    public UILabel btnname;
    static Stagebtninfo _instance;
    public static Stagebtninfo instance()
    {
        return _instance;
    }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        origin = GetComponent<UISprite>().spriteName;        
    }
    void Update()
    {
        unlock = PlayerPrefs.GetInt("unlock") + 2;
        if (stnum < unlock)
        {
            GetComponent<UISprite>().spriteName = origin;
            btnname.text = "" + stnum;
        }
        else
        {
            GetComponent<UISprite>().spriteName = "lock3";
            btnname.text = "";
        }
    }
    public void Setuispeed(int num)
    {
        if (btnname.text == "")
        {
            return;
        }
        PlayerPrefs.SetString("stage","STAGE\n"+num);
        int realnum = num - 1;
        PlayerPrefs.SetInt("realnum", num);
        switch (realnum)
        {
            case 0:
                PlayerPrefs.SetFloat("mintime", 1f);
                PlayerPrefs.SetFloat("maxtime", 1.2f);
                break;
            case 1:
                PlayerPrefs.SetFloat("mintime", 0.9f);
                PlayerPrefs.SetFloat("maxtime", 1.1f);
                break;
            case 2:
                PlayerPrefs.SetFloat("mintime", 0.85f);
                PlayerPrefs.SetFloat("maxtime", 1.05f);
                break;
            case 3:
                PlayerPrefs.SetFloat("mintime", 0.8f);
                PlayerPrefs.SetFloat("maxtime", 1f);
                break;
            case 4:
                PlayerPrefs.SetFloat("mintime", 0.75f);
                PlayerPrefs.SetFloat("maxtime", 0.95f);
                break;
            case 5:
                PlayerPrefs.SetFloat("mintime", 0.7f);
                PlayerPrefs.SetFloat("maxtime", 0.9f);
                break;
            case 6:
                PlayerPrefs.SetFloat("mintime", 0.65f);
                PlayerPrefs.SetFloat("maxtime", 0.85f);
                break;
            case 7:
                PlayerPrefs.SetFloat("mintime", 0.6f);
                PlayerPrefs.SetFloat("maxtime", .8f);
                break;
            case 8:
                PlayerPrefs.SetFloat("mintime", .55f);
                PlayerPrefs.SetFloat("maxtime", .75f);
                break;
            case 9:
                PlayerPrefs.SetFloat("mintime", .5f);
                PlayerPrefs.SetFloat("maxtime", .7f);
                break;
            case 10:
                PlayerPrefs.SetFloat("mintime", .52f);
                PlayerPrefs.SetFloat("maxtime", .6f);
                break;
            case 11:
                PlayerPrefs.SetFloat("mintime", .48f);
                PlayerPrefs.SetFloat("maxtime", .56f);
                break;
            case 12:
                PlayerPrefs.SetFloat("mintime", .44f);
                PlayerPrefs.SetFloat("maxtime", .52f);
                break;
            case 13:
                PlayerPrefs.SetFloat("mintime", .4f);
                PlayerPrefs.SetFloat("maxtime", .48f);
                break;
            case 14:
                PlayerPrefs.SetFloat("mintime", .36f);
                PlayerPrefs.SetFloat("maxtime", .44f);
                break;
            case 15:
                PlayerPrefs.SetFloat("mintime", .32f);
                PlayerPrefs.SetFloat("maxtime", .4f);
                break;
            case 16:
                PlayerPrefs.SetFloat("mintime", .28f);
                PlayerPrefs.SetFloat("maxtime", .36f);
                break;
            case 17:
                PlayerPrefs.SetFloat("mintime", .24f);
                PlayerPrefs.SetFloat("maxtime", .32f);
                break;
            case 18:
                PlayerPrefs.SetFloat("mintime", .2f);
                PlayerPrefs.SetFloat("maxtime", .28f);
                break;
            case 19:
                PlayerPrefs.SetFloat("mintime", .16f);
                PlayerPrefs.SetFloat("maxtime", .24f);
                break;
            case 20:
                PlayerPrefs.SetFloat("mintime", .18f);
                PlayerPrefs.SetFloat("maxtime", 0.2f);
                break;
            case 21:
                PlayerPrefs.SetFloat("mintime", .17f);
                PlayerPrefs.SetFloat("maxtime", .19f);
                break;
            case 22:
                PlayerPrefs.SetFloat("mintime", .16f);
                PlayerPrefs.SetFloat("maxtime", .18f);
                break;
            case 23:
                PlayerPrefs.SetFloat("mintime", .15f);
                PlayerPrefs.SetFloat("maxtime", .17f);
                break;
            case 24:
                PlayerPrefs.SetFloat("mintime", .14f);
                PlayerPrefs.SetFloat("maxtime", .16f);
                break;
            case 25:
                PlayerPrefs.SetFloat("mintime", .13f);
                PlayerPrefs.SetFloat("maxtime", .15f);
                break;
            case 26:
                PlayerPrefs.SetFloat("mintime", .12f);
                PlayerPrefs.SetFloat("maxtime", .14f);
                break;
            case 27:
                PlayerPrefs.SetFloat("mintime", .11f);
                PlayerPrefs.SetFloat("maxtime", .13f);
                break;
            case 28:
                PlayerPrefs.SetFloat("mintime", .1f);
                PlayerPrefs.SetFloat("maxtime", .12f);
                break;
            case 29:
                PlayerPrefs.SetFloat("mintime", .09f);
                PlayerPrefs.SetFloat("maxtime", .11f);
                break;
        }
        Application.LoadLevel(1);
    }
}

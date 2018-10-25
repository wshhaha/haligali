using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singelstage : MonoBehaviour 
{    
    public int unlocknum;
    public int stagenum;

	void Start () 
	{        
        unlocknum = PlayerPrefs.GetInt("unlock");
        stagenum = PlayerPrefs.GetInt("realnum");
	}	
	
    public void Nextstageset()
    {
        
        if (stagenum == (unlocknum+1))
        {
            unlocknum++;
            if (unlocknum >= 29)
            {
                unlocknum = 29;
            }
        }
        stagenum++;
        if (stagenum > 30)
        {
            stagenum = 30;
        }
        Stagebtninfo.instance().Setuispeed(stagenum);
        PlayerPrefs.SetString("stage", "STAGE\n"+stagenum);
        PlayerPrefs.SetInt("unlock", unlocknum);        
        Application.LoadLevel(1);
    }
}
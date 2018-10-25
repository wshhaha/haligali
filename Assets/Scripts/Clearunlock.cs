using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearunlock : MonoBehaviour 
{
	public void Resetunlock()
    {
        PlayerPrefs.SetInt("unlock", 0);
    }
}

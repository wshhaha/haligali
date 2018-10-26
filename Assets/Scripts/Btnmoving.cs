using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btnmoving : MonoBehaviour 
{
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public Vector3 upori;
    public Vector3 downori;
    public Vector3 leftori;
    public Vector3 rightori;

    void Start () 
	{
        Setposition();
        StartCoroutine("Gamestart");
    }	
	
    void Setposition()
    {
        upori = new Vector3(0, 200, 0);
        downori = new Vector3(0, -300, 0);
        leftori = new Vector3(-300, 0, 0);
        rightori = new Vector3(300, 0, 0);
    }
    IEnumerator Gamestart()
    {
        float i = 1;
        while (i>0)
        {
            up.transform.localPosition = upori * i;
            down.transform.localPosition = downori * i;
            left.transform.localPosition = leftori * i;
            right.transform.localPosition = rightori * i;
            i -= 0.02f;
            yield return new WaitForEndOfFrame();
        }
        up.transform.localPosition = Vector3.zero;
        down.transform.localPosition = Vector3.zero;
        left.transform.localPosition = Vector3.zero;
        right.transform.localPosition = Vector3.zero;
    }
}

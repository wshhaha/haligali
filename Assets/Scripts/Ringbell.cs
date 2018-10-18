using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ringbell : MonoBehaviour 
{
    public GameObject counter;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    void Start()
    {
        p1 = GameObject.Find("1P");
        p2 = GameObject.Find("2P");
        p3 = GameObject.Find("3P");
        p4 = GameObject.Find("4P");
    }

    public void Ring()
    {
        if (counter.GetComponent<Fruitcounter>().canwin == true)
        {
            foreach (var item in counter.GetComponent<Fruitcounter>().opencard)
            {
                item.transform.parent = transform;
                GetComponent<Havecard>().remaincard.Add(item);
                item.transform.localPosition = Vector3.zero;
                item.transform.localRotation = Quaternion.Euler(0, 0, 0);                
            }
            counter.GetComponent<Fruitcounter>().opencard.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    counter.GetComponent<Fruitcounter>().num[i][j] = 0;
                }   
            }
        }
        else
        {
            if (GetComponent<Havecard>().remaincard.Count >= 3)
            {
                switch (gameObject.name)
                {
                    case "1P":                        
                        GetComponent<Havecard>().remaincard[0].transform.parent = p2.transform;
                        GetComponent<Havecard>().remaincard[0].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[0].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p2.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[0]);
                        GetComponent<Havecard>().remaincard[1].transform.parent = p3.transform;
                        GetComponent<Havecard>().remaincard[1].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[1].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p3.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[1]);
                        GetComponent<Havecard>().remaincard[2].transform.parent = p4.transform;
                        GetComponent<Havecard>().remaincard[2].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[2].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p4.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[2]);
                        GetComponent<Havecard>().remaincard.RemoveRange(0, 3);
                        break;
                    case "2P":
                        GetComponent<Havecard>().remaincard[0].transform.parent = p3.transform;
                        GetComponent<Havecard>().remaincard[0].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[0].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p3.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[0]);
                        GetComponent<Havecard>().remaincard[1].transform.parent = p4.transform;
                        GetComponent<Havecard>().remaincard[1].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[1].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p4.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[1]);
                        GetComponent<Havecard>().remaincard[2].transform.parent = p1.transform;
                        GetComponent<Havecard>().remaincard[2].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[2].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p1.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[2]);
                        GetComponent<Havecard>().remaincard.RemoveRange(0, 3);
                        break;
                    case "3P":
                        GetComponent<Havecard>().remaincard[0].transform.parent = p4.transform;
                        GetComponent<Havecard>().remaincard[0].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[0].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p4.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[0]);
                        GetComponent<Havecard>().remaincard[1].transform.parent = p1.transform;
                        GetComponent<Havecard>().remaincard[1].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[1].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p1.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[1]);
                        GetComponent<Havecard>().remaincard[2].transform.parent = p2.transform;
                        GetComponent<Havecard>().remaincard[2].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[2].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p2.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[2]);
                        GetComponent<Havecard>().remaincard.RemoveRange(0, 3);
                        break;
                    case "4P":
                        GetComponent<Havecard>().remaincard[0].transform.parent = p1.transform;
                        GetComponent<Havecard>().remaincard[0].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[0].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p1.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[0]);
                        GetComponent<Havecard>().remaincard[1].transform.parent = p2.transform;
                        GetComponent<Havecard>().remaincard[1].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[1].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p2.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[1]);
                        GetComponent<Havecard>().remaincard[2].transform.parent = p3.transform;
                        GetComponent<Havecard>().remaincard[2].transform.localPosition = Vector3.zero;
                        GetComponent<Havecard>().remaincard[2].transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p3.GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[2]);
                        GetComponent<Havecard>().remaincard.RemoveRange(0, 3);
                        break;
                }
            }
        }
    }
}
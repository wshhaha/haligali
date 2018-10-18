using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reversecard : MonoBehaviour 
{
    public bool check=false;
    public GameObject counter;    

	void Start () 
	{
		
	}
	
	void Update () 
	{        
        if (check == true&&GetComponent<Yourturn>().turn==true)
        {
            if (GetComponent<Havecard>().remaincard.Count == 0)
            {
                check = false;
                GetComponent<Yourturn>().turn = false;
                return;
            }
            switch (gameObject.name)
            {
                case "1P":
                    GetComponent<Havecard>().remaincard[0].transform.localPosition = new Vector3(0, 1.5f, 0);
                    GetComponent<Havecard>().remaincard[0].transform.Rotate(180, 0, 0);
                    GetComponent<Havecard>().remaincard[0].transform.parent = counter.transform;
                    counter.GetComponent<Fruitcounter>().opencard.Add(GetComponent<Havecard>().remaincard[0]);
                    switch (GetComponent<Havecard>().remaincard[0].tag)
                    {
                        case "red":
                            counter.GetComponent<Fruitcounter>().p1r = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p1y = 0;
                            counter.GetComponent<Fruitcounter>().p1g = 0;
                            counter.GetComponent<Fruitcounter>().p1v = 0;
                            break;
                        case "yellow":
                            counter.GetComponent<Fruitcounter>().p1r = 0;
                            counter.GetComponent<Fruitcounter>().p1y = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p1g = 0;
                            counter.GetComponent<Fruitcounter>().p1v = 0;
                            break;
                        case "green":
                            counter.GetComponent<Fruitcounter>().p1r = 0;
                            counter.GetComponent<Fruitcounter>().p1y = 0;
                            counter.GetComponent<Fruitcounter>().p1g = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p1v = 0;
                            break;
                        case "violet":
                            counter.GetComponent<Fruitcounter>().p1r = 0;
                            counter.GetComponent<Fruitcounter>().p1y = 0;
                            counter.GetComponent<Fruitcounter>().p1g = 0;
                            counter.GetComponent<Fruitcounter>().p1v = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            break;
                    }
                    GetComponent<Havecard>().remaincard.RemoveAt(0);
                    break;
                case "2P":
                    GetComponent<Havecard>().remaincard[0].transform.localPosition = new Vector3(0, 1.5f, 0);
                    GetComponent<Havecard>().remaincard[0].transform.Rotate(180, 0, 0);
                    GetComponent<Havecard>().remaincard[0].transform.parent = counter.transform;
                    counter.GetComponent<Fruitcounter>().opencard.Add(GetComponent<Havecard>().remaincard[0]);
                    switch (GetComponent<Havecard>().remaincard[0].tag)
                    {
                        case "red":
                            counter.GetComponent<Fruitcounter>().p2r = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p2y = 0;
                            counter.GetComponent<Fruitcounter>().p2g = 0;
                            counter.GetComponent<Fruitcounter>().p2v = 0;
                            break;
                        case "yellow":
                            counter.GetComponent<Fruitcounter>().p2r = 0;
                            counter.GetComponent<Fruitcounter>().p2y = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p2g = 0;
                            counter.GetComponent<Fruitcounter>().p2v = 0;
                            break;
                        case "green":
                            counter.GetComponent<Fruitcounter>().p2r = 0;
                            counter.GetComponent<Fruitcounter>().p2y = 0;
                            counter.GetComponent<Fruitcounter>().p2g = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p2v = 0;
                            break;
                        case "violet":
                            counter.GetComponent<Fruitcounter>().p2r = 0;
                            counter.GetComponent<Fruitcounter>().p2y = 0;
                            counter.GetComponent<Fruitcounter>().p2g = 0;
                            counter.GetComponent<Fruitcounter>().p2v = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            break;
                    }
                    GetComponent<Havecard>().remaincard.RemoveAt(0);
                    break;
                case "3P":
                    GetComponent<Havecard>().remaincard[0].transform.localPosition = new Vector3(0, 1.5f, 0);
                    GetComponent<Havecard>().remaincard[0].transform.Rotate(180, 0, 0);
                    GetComponent<Havecard>().remaincard[0].transform.parent = counter.transform;
                    counter.GetComponent<Fruitcounter>().opencard.Add(GetComponent<Havecard>().remaincard[0]);
                    switch (GetComponent<Havecard>().remaincard[0].tag)
                    {
                        case "red":
                            counter.GetComponent<Fruitcounter>().p3r = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p3y = 0;
                            counter.GetComponent<Fruitcounter>().p3g = 0;
                            counter.GetComponent<Fruitcounter>().p3v = 0;
                            break;
                        case "yellow":
                            counter.GetComponent<Fruitcounter>().p3r = 0;
                            counter.GetComponent<Fruitcounter>().p3y = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p3g = 0;
                            counter.GetComponent<Fruitcounter>().p3v = 0;
                            break;
                        case "green":
                            counter.GetComponent<Fruitcounter>().p3r = 0;
                            counter.GetComponent<Fruitcounter>().p3y = 0;
                            counter.GetComponent<Fruitcounter>().p3g = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p3v = 0;
                            break;
                        case "violet":
                            counter.GetComponent<Fruitcounter>().p3r = 0;
                            counter.GetComponent<Fruitcounter>().p3y = 0;
                            counter.GetComponent<Fruitcounter>().p3g = 0;
                            counter.GetComponent<Fruitcounter>().p3v = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            break;
                    }
                    GetComponent<Havecard>().remaincard.RemoveAt(0);
                    break;
                case "4P":
                    GetComponent<Havecard>().remaincard[0].transform.localPosition = new Vector3(0, 1.5f, 0);
                    GetComponent<Havecard>().remaincard[0].transform.Rotate(180, 0, 0);
                    GetComponent<Havecard>().remaincard[0].transform.parent = counter.transform;
                    counter.GetComponent<Fruitcounter>().opencard.Add(GetComponent<Havecard>().remaincard[0]);
                    switch (GetComponent<Havecard>().remaincard[0].tag)
                    {
                        case "red":
                            counter.GetComponent<Fruitcounter>().p4r = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p4y = 0;
                            counter.GetComponent<Fruitcounter>().p4g = 0;
                            counter.GetComponent<Fruitcounter>().p4v = 0;
                            break;
                        case "yellow":
                            counter.GetComponent<Fruitcounter>().p4r = 0;
                            counter.GetComponent<Fruitcounter>().p4y = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p4g = 0;
                            counter.GetComponent<Fruitcounter>().p4v = 0;
                            break;
                        case "green":
                            counter.GetComponent<Fruitcounter>().p4r = 0;
                            counter.GetComponent<Fruitcounter>().p4y = 0;
                            counter.GetComponent<Fruitcounter>().p4g = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            counter.GetComponent<Fruitcounter>().p4v = 0;
                            break;
                        case "violet":
                            counter.GetComponent<Fruitcounter>().p4r = 0;
                            counter.GetComponent<Fruitcounter>().p4y = 0;
                            counter.GetComponent<Fruitcounter>().p4g = 0;
                            counter.GetComponent<Fruitcounter>().p4v = GetComponent<Havecard>().remaincard[0].GetComponent<Cardstat>().numfruit;
                            break;
                    }
                    GetComponent<Havecard>().remaincard.RemoveAt(0);
                    break;
            }
            check = false;
            GetComponent<Yourturn>().turn = false;
        }
        else
        {
            check = false;
        }
	}

    public void Pushbtn()
    {
        check = true;
    }
}
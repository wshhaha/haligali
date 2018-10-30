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
    public List<GameObject> p;
    public int remain;
    public UILabel nextround;
    public AudioClip bellsound;
    public int pncnt;
    public int lpcnt;
    public bool wait;

    void Start()
    {
        Setplayer();        
    }
    public void Taketurn(int num)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == num)
            {
                p[i].GetComponent<Yourturn>().turn = true;
            }
            else
            {
                p[i].GetComponent<Yourturn>().turn = false;
            }
        }
    }
    void Setplayer()
    {
        p1 = GameObject.Find("1P");
        p2 = GameObject.Find("2P");
        p3 = GameObject.Find("3P");
        p4 = GameObject.Find("4P");
        p = new List<GameObject>();
        p.Add(p1);
        p.Add(p2);
        p.Add(p3);
        p.Add(p4);
        p.Add(p1);
        p.Add(p2);
        p.Add(p3);
        p.Add(p4);
    }
    
    IEnumerator Penelity(int num, int need)
    {
        if (counter.GetComponent<Fruitcounter>().opencard.Count == 0)
        {
            yield break;
        }
        pncnt = 0;
        for (int i = 0; i < 3; i++)
        {
            if (GetComponent<Havecard>().remaincard.Count == 0)
            {
                yield break;
            }
            if (p[(num + 1 + i)].GetComponent<Yourturn>().lose == false)
            {
                GetComponent<Havecard>().remaincard[0].transform.parent = p[(num + 1 + i)].transform;
                print(p[(num + 1 + i)].gameObject.name);
                Vector3 ori = GetComponent<Havecard>().remaincard[0].transform.localPosition;
                Vector3 adj = - GetComponent<Havecard>().remaincard[0].transform.position + p[(num + 1 + i)].transform.position;
                for (float j = 0; j < 1; j += 0.2f)
                {
                    GetComponent<Havecard>().remaincard[0].transform.Translate(adj/5, Space.World);
                    yield return new WaitForEndOfFrame();
                }
                GetComponent<Havecard>().remaincard[0].transform.localPosition = Vector3.zero;
                GetComponent<Havecard>().remaincard[0].transform.localRotation = Quaternion.Euler(0, 0, 0);
                p[((num + 1 + i))].GetComponent<Havecard>().remaincard.Add(GetComponent<Havecard>().remaincard[0]);
                GetComponent<Havecard>().remaincard.Remove(GetComponent<Havecard>().remaincard[0]);
                pncnt++;
            }
            if (pncnt == need)
            {
                wait = false;
                yield break;
            }
        }        
    }
    
    IEnumerator Takemove(GameObject obj)
    {
        Vector3 ori = obj.transform.localPosition;
        for (float i = 1; i > 0; i -= 0.2f)
        {
            obj.transform.localPosition = ori * i;
            yield return new WaitForEndOfFrame();
        }
        obj.transform.localPosition = Vector3.zero;
    }
    public void Takecard()
    {
        foreach (var item in counter.GetComponent<Fruitcounter>().opencard)
        {
            item.transform.parent = transform;
            item.GetComponent<UIPanel>().depth = 0;
            GetComponent<Havecard>().remaincard.Add(item);
            StartCoroutine("Takemove", item);
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
        nextround.text = "";
    }
    public void Sendwinner()
    {
        counter.GetComponent<Fruitcounter>().roundwinner = gameObject.name;
    }
    public void Liveplayer()
    {
        lpcnt = 0;
        for (int i = 0; i < 4; i++)
        {
            if (counter.GetComponent<Fruitcounter>().build.GetComponent<Builddeck>().p[i].GetComponent<Yourturn>().lose == false)
            {
                lpcnt++; 
            }
        }        
    }
    public void Ring()
    {
        if (GetComponent<Yourturn>().lose == true)
        {
            return;
        }
        if (wait == true)
        {
            return;
        }
        wait = true;
        Effectsound.instance().Sfxplay(bellsound);
        if (counter.GetComponent<Fruitcounter>().canwin == true)
        {
            Sendwinner();
            switch (gameObject.name)
            {
                case "1P":
                    Taketurn(0);
                    break;
                case "2P":
                    Taketurn(1);
                    break;
                case "3P":
                    Taketurn(2);
                    break;
                case "4P":
                    Taketurn(3);
                    break;
            }            
            counter.GetComponent<Fruitcounter>().endround = true;
            nextround.text = "Round\nWinner\n" + gameObject.name;
            wait = false;
        }
        if(counter.GetComponent<Fruitcounter>().canwin ==false && counter.GetComponent<Fruitcounter>().endround == false)
        {
            if (GetComponent<Havecard>().remaincard.Count == 0)
            {
                return;
            }
            if (GetComponent<Havecard>().remaincard.Count <= 2)
            {
                Liveplayer();
                switch (gameObject.name)
                {
                    case "1P":
                        StartCoroutine(Penelity(0, lpcnt - 1));
                        break;
                    case "2P":
                        StartCoroutine(Penelity(1, lpcnt - 1));
                        break;
                    case "3P":
                        StartCoroutine(Penelity(2, lpcnt - 1));
                        break;
                    case "4P":
                        StartCoroutine(Penelity(3, lpcnt - 1));
                        break;
                }
            }
            else
            {
                Liveplayer();
                switch (gameObject.name)
                {
                    case "1P":
                        StartCoroutine(Penelity(0, lpcnt - 1));
                        break;
                    case "2P":
                        StartCoroutine(Penelity(1, lpcnt - 1));
                        break;
                    case "3P":
                        StartCoroutine(Penelity(2, lpcnt - 1));
                        break;
                    case "4P":
                        StartCoroutine(Penelity(3, lpcnt - 1));
                        break;
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimelyObjInterect : MonoBehaviour
{
    GameObject PoiterArrow;
    Item item;
    public bool needItem;
    NeedIDscript needIDscript;
    //TextMesh timeTxt;
    BossBar bossBar;
    public float[] times = new float[4];//0-1start,2-3 end
    public float timeTOend, timeTOstart;
    public GameObject otherObj;
    // Start is called before the first frame update
    void Start()
    {
        timeTOstart = Random.Range(times[0]/2, times[1]/2);
        //timeTxt = GetComponentInChildren<TextMesh>();
        needIDscript = GetComponent<NeedIDscript>();
        //Invoke("FindBossBar", 0.2f);
        bossBar = GameObject.Find("BossBar").GetComponent<BossBar>();
        if (needItem)
            PoiterArrow = GameObject.Find("Arrow");
    }
    //void FindBossBar()
    //{
    //    bossBar = GameObject.Find("BossBar").GetComponent<BossBar>();
    //}
    // Update is called once per frame
    void Update()
    {
        Timertostart();
        Timertoend();
    }
    void Timertoend()//отсщет до конца event
    {
        if (timeTOend > 0)
        {
            timeTOend -= Time.deltaTime;
            //timeTxt.text = ((int)timeTOend).ToString();
            if (timeTOend <= 0)
            {
                if (timeTOstart <= 0)//время кончилось --> провал
                {
                    Debug.Log("end");
                    //timeTxt.text = "fail";
                    bossBar.PlusOneAngry();//функция в bosbar( + к шкале bossAngry)
                    timeTOstart = Random.Range(times[0], times[1]);//определение до старта следующего event
                    if (needItem)
                        otherObj.BroadcastMessage("destroyItem", otherObj.transform);
                }
            }
        }

    }
    void Timertostart()//отсщет до старта event
    {
        if (timeTOstart > 0)
        {
            timeTOstart -= Time.deltaTime;
            if (timeTOstart <= 0)
            {
                if (timeTOend <= 0)
                {
                    Debug.Log("start");
                    timeTOend = Random.Range(times[2], times[3]);
                    if (needItem)
                    {
                        otherObj.BroadcastMessage("Gener",otherObj.transform);
                        Debug.Log("broadcast");
                        // PoiterArrow.transform.position = new Vector3(otherObj.transform.position.x, otherObj.transform.position.y + 4, transform.position.z);
                    }
                }
            }
        }
    }
    public void ActToObj(Transform player)
    {
        if (needItem)//Если нужен предмет
        {
            if (player.childCount > 0)//есть ли у игрока предмет
            {
                item = player.GetChild(0).GetComponent<Item>();
                item = player.GetComponentInChildren<Item>();
                if (needIDscript.ItemID == item.ID)
                {
                    Debug.Log("sas");
                    Destroy(item.gameObject, 0.2f);
                    if (timeTOend > 0)
                        Comlitle();//взаимодействие завершено
                }
            }
        }
        else if (timeTOend > 0)//если у игрока нет предмета то: только если время не закончилось:
            Comlitle();//взаимодействие без предмета завершено
    }
    void Comlitle()
    {
        //timeTxt.text = "good";
        timeTOstart = Random.Range(times[0], times[1]);
        timeTOend = 0f;
    }
}
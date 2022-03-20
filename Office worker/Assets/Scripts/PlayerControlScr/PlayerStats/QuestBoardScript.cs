using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoardScript : MonoBehaviour {
    TextMesh Quests;
    public List<int> questProgress=new List<int> {};
    public List<GameObject> startObj = new List<GameObject> { };
    BossBar bossBar;
    public float timeTOend, timeTOstart;//время до нового квеста
    // Use this for initialization
    void Start () {
        questProgress.Add(0);
        questProgress.Add(1);
        questProgress.Add(5);
        Quests = GetComponent<TextMesh>();
        bossBar = GameObject.Find("BossBar").GetComponent<BossBar>();
        timeTOstart = Random.Range(5, 10);
        //Quests.text = "Find" + questProgress[0] + "papers\"nFind" + questProgress[1] + "flawours";
    }

    // Update is called once per frame
    void Update() {
        Timertoend();
        Timertostart();
    }
    void Timertoend()//отсщет до конца event
    {
        if (timeTOend > 0)
        {
            Quests.text = "Find " + questProgress[1] + " papers";
            timeTOend -= Time.deltaTime;
            //timeTxt.text = ((int)timeTOend).ToString();
            if (questProgress[1] == 0)
            {
                timeTOstart = timeTOstart = Random.Range(24, 28);
                timeTOend = 0f;
            }
            if (timeTOend <= 0)
            {
                if (timeTOstart <= 0)//время кончилось --> провал
                {
                    Debug.Log("end");
                    //timeTxt.text = "fail";
                    bossBar.PlusOneAngry();//функция в bosbar( + к шкале bossAngry)
                    timeTOstart = Random.Range(16, 20);//определение до старта следующего event
                    startObj[0].BroadcastMessage("destroyItem", startObj[0].transform);
                }
            }
        }

    }
    void Timertostart()//отсщет до старта event
    {
        if (timeTOstart > 0)
        {
            Quests.text = "complite";
            timeTOstart -= Time.deltaTime;
            if (timeTOstart <= 0)
            {
                if (timeTOend <= 0)
                {
                    Debug.Log("start");
                    questProgress[1] = 1;
                    timeTOend = Random.Range(24, 30);
                    startObj[0].BroadcastMessage("Gener", startObj[0].transform);
                    Debug.Log("broadcast");
                    // PoiterArrow.transform.position = new Vector3(otherObj.transform.position.x, otherObj.transform.position.y + 4, transform.position.z);
                }
            }
        }
    }
    void QuestDone()
    {
        //timeTxt.text = "good";
        timeTOstart = Random.Range(24, 28);
        timeTOend = 0f;
    }
}

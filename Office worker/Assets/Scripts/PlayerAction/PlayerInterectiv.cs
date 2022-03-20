using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterectiv : MonoBehaviour {
    public ActionButton actionButton;
    Collider ActionObj;
    ObjScript objScript;
    ReloadObj reloadObj;
    OneoffObj oneoffObj;
    NeedIDscript needIDscript;
    TimelyObjInterect timelyOgj;
    Walking walking;
    float DoingTime;
    // Use this for initialization
    //public int HandSlotID;
	void Start () {
        walking = GetComponent<Walking>();
    }
	
	// Update is called once per frame
	void Update () {

	}
    private void OnTriggerEnter(Collider other)//вход в зону взаимодействия с обьектом
    {
     //   Debug.Log("Enter");
        if (other.tag == "ActionObj")
        {
            ActionObj = other;
            actionButton.On();
        }
    }
    private void OnTriggerExit(Collider other)//выход из зону взаимодействия с обьектом
    {
        //  Debug.Log("Exit");
        if (other.tag == "ActionObj")
        {
            actionButton.Off();
        }
    }
    public void Act()//функция взаимодействия игрока с предметами всех типов
    {
        
        objScript = ActionObj.GetComponent<ObjScript>();
        reloadObj = ActionObj.GetComponent<ReloadObj>();
        timelyOgj = ActionObj.GetComponent<TimelyObjInterect>();
        oneoffObj = ActionObj.GetComponent<OneoffObj>();
        if (objScript != null)//взаимодействие с об. обычным обьектом (создание,обработка,сдача предметов)
        {
           // Debug.Log(HandSlotID);
            if(transform.childCount > 0)//если у игрока есть предмет
                objScript.PutQuestItem(transform.GetChild(0),transform);//функция положить(отдать) 
            if (transform.childCount == 0)//если у игрока нет предмета
                objScript.GetItem(transform);//вызывает функцию отдовая предмета в обьекте 
        }
        if (reloadObj != null)//взаимодействие с перезаряжаймым об.(перезарядка)
        {
            if (transform.childCount > 0)//есть ли у игрока предмет
            {
                reloadObj.Reload(transform.GetChild(0));//вызывает функцию востонавления зарядов в обьекте
                DoingTime += 2f;//время выполнения работы +=2;
                Destroy(transform.GetChild(0).gameObject, 1.5f);
            }
        }
        if (timelyOgj != null)//взаимодействие с переодическим об.
        {
            Debug.Log("T");
            timelyOgj.ActToObj(transform);//вызов функции ActToObj,взаимодействие с timelyObj
            DoingTime += 3f;//время выполнения работы +=3;
        }
        if(oneoffObj != null)//взаимодействие с одноразовым обьектом 
        {
            oneoffObj.UseObj();//вызывает UseObj в oneoffObj
            DoingTime = oneoffObj.DoingTime;//время выполнения работы =...;
        }
        walking.Stay(DoingTime);//вызывает функцию Stay из walking (в player)
        DoingTime = 0;
    }
}

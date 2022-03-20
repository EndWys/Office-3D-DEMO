using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjScript : MonoBehaviour {
    Transform item;
    public bool TakeItem, PutItem, GenerItem, Qustable;
    public int QuestID;
    Item itemScript;
    NeedIDscript needIDscript;
    QuestBoardScript questBoard;
    PlayerInterectiv interctivPlayer;
    public Vector3 ItemPlace;
    //public Vector3 PointerPlace;
    //TimingObj timingObj;
    void Start () {
        Invoke("FindQuestBoard", 0.2f);
        needIDscript = GetComponent<NeedIDscript>();
    }
    void FindQuestBoard()
    {
        questBoard = GameObject.Find("QuestsBoard").GetComponent<QuestBoardScript>();
    }
	public void QuestDone()
    {
        questBoard.questProgress[QuestID]--;
    }
	// Update is called once per frame
    public void PutQuestItem(Transform item,Transform player)//сдать предмет
    {
        //Debug.Log("G");
        if (PutItem)
        {
            itemScript = item.gameObject.GetComponent<Item>();//для получения информации о предмете, в компоненте (скрипте) item;
            if (itemScript.ID == needIDscript.ItemID && itemScript.underID == needIDscript.underIDneed)//проверка на правельность ID и подID предмета
            {
                //interctivPlayer = player.gameObject.GetComponent<PlayerInterectiv>();
                item.transform.SetParent(transform);
                item.localPosition = ItemPlace;
                item.localRotation = Quaternion.identity;
                itemScript.underID++;
                //itemScript.Droped();
               // Debug.Log("Put");
                if (Qustable)//последний этап поручения?
                {
                    QuestDone();//поручение выполнено
                }
            }
        }
    }
    public void GetItem(Transform player)
    {
        //Debug.Log("Geting");
        if (TakeItem)
        {
            Debug.Log("Get");
            if (transform.childCount > needIDscript.BaseChild && transform.GetChild(needIDscript.BaseChild).tag=="Item")//есть ли у обьекта предмет && является ли это предметом
            {
                item = transform.GetChild(needIDscript.BaseChild);
                item.SetParent(player);
                Debug.Log("Get");
                GetingSetings(player);
            }
            else if(GenerItem)
            {
                Gener(player);
                GetingSetings(player);
            }
        }
    }
    void Gener(Transform parent)//функция создания предмета
    {
        GameObject itemGO = Instantiate(Resources.Load(needIDscript.ItemGener), parent, false) as GameObject;
        item = itemGO.transform;
        Debug.Log("Gener");
    }
    void destroyItem()
    {
        Destroy(item.gameObject, 0.2f);
    }
    void GetingSetings(Transform player)//функция параметров для предмета
    {
        item.localPosition = new Vector3(0, 0, 1);
        item.localRotation = Quaternion.identity;
        //interctivPlayer = player.gameObject.GetComponent<PlayerInterectiv>();
        itemScript = item.gameObject.GetComponent<Item>();//ссылка на компонент Item с информацией о предмете 
        //itemScript.FindTarget();
    }
}

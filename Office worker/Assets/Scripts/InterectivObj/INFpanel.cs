using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class INFpanel : MonoBehaviour
{
    //ObjScript objScript;
    ObjScript objScript;
    OneoffObj oneoffObj;
    ReloadObj reloadObj;
    TimelyObjInterect timelyObj;
    NeedIDscript needIDscript;
    public Sprite[] Icons;
    SpriteRenderer itemSprite, actionIcon;
    Transform ChargeIndicator;
    TextMesh Timer;
    SpriteRenderer HandIcon;
    //<timer>
    //</timer>
    void Start()
    {
        needIDscript = GetComponentInParent<NeedIDscript>();
        objScript = GetComponentInParent<ObjScript>();
        timelyObj = GetComponentInParent<TimelyObjInterect>();
        reloadObj= GetComponentInParent<ReloadObj>();
        oneoffObj = GetComponentInParent<OneoffObj>();
        itemSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        actionIcon = transform.GetChild(1).GetComponent<SpriteRenderer>();
        ChargeIndicator = transform.GetChild(2);
        Timer = transform.GetChild(3).GetComponent<TextMesh>();
    }

    // Update is called once per frame
    bool next_step_Quest()
    {
        Item players_item = GameObject.Find("Player").GetComponentInChildren<Item>();
        if (needIDscript.ItemID == objScript.QuestID)
        {
            if (players_item != null && needIDscript.underIDneed == players_item.underID)
                return true;
            else if (objScript.GetComponentInChildren<Item>() && needIDscript.underIDneed ==0)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    void Update()
    {
        if (objScript != null)
        {
            if (next_step_Quest())
                transform.localScale = new Vector3(3.2f, 3.3f, 1);
            else
                transform.localScale = new Vector3(0, 0, 0);
        }
        else if (reloadObj!= null)
        {
            itemSprite.sprite = Icons[0];
            ChargeIndicator.localScale = new Vector3(0.2f, (float)reloadObj.charge / reloadObj.maxCharge,0.3f);
            Timer.text = "";
            actionIcon.sprite = Icons[1]; 
        }
        else if (timelyObj != null)
        {
            string Timetxt;
            Timetxt = timelyObj.timeTOend % 60 == 0 ?
            Timetxt = (timelyObj.timeTOend / 60) + ":" + "00" : (int)timelyObj.timeTOend % 60 >= 10 ?
            Timetxt = "0"+ ((int)timelyObj.timeTOend / 60) + ":" + ((int)timelyObj.timeTOend % 60) : Timetxt = ((int)timelyObj.timeTOend / 60) + ":" + "0" + ((int)timelyObj.timeTOend % 60);
            Timer.text =Timetxt.ToString();
            //Timer.text = ((int)timelyObj.timeTOend).ToString();
            itemSprite.sprite = Icons[0];
            ChargeIndicator.localScale = Vector3.zero;
            actionIcon.sprite = Icons[1];
            if (timelyObj.timeTOend > 0)
                transform.localScale = new Vector3(3.2f, 3.3f, 1);
            else
                transform.localScale = new Vector3(0, 0, 0);
        }
        else if (oneoffObj != null)
        {
            itemSprite.sprite = Icons[0];
            Timer.text = oneoffObj.DoingTime + "s";
            ChargeIndicator.localScale = Vector3.zero;
            actionIcon.sprite = Icons[1];
        }
        else if (needIDscript != null)
        {
            if (needIDscript.GenerItem)
            {
                itemSprite.sprite = Icons[0];
                Timer.text = "";
                ChargeIndicator.localScale = Vector3.zero;
                actionIcon.sprite = Icons[1];
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadObj : MonoBehaviour {
    BossBar bossBar;
    TextMesh text;
    public int charge;
    public bool Infinit;//настройка для бесконечных зарядов
    public int maxCharge = 10;
    Item itemScript;
    NeedIDscript needIDscript;
    private void Start()
    {
        text = transform.GetChild(0).GetComponent<TextMesh>();
        needIDscript = GetComponent<NeedIDscript>();
        charge = maxCharge;
        //text.text = charge.ToString();
        Invoke("FindBossBar", 0.2f);
    }
    void FindBossBar()
    {
        bossBar = GameObject.Find("BossBar").GetComponent<BossBar>();
    }
    public void UseObj()//взаимодействие с обьектом с использованием зарядов [ для NPC ]
    {
        if (charge > 0)
        {
            if(!Infinit)
            charge--;
        }
        else
        {
            bossBar.angry++;
        }
    }
    public void Reload(Transform item)//перезарядка обьекта
    {
        itemScript = item.GetComponent<Item>();
        if (itemScript.ID == needIDscript.ItemID)//проврка на наличие прдмета нужного для презарядки 
        {
            charge = maxCharge;//перезарядка
            //text.text = charge.ToString();
        }
    }
    
}

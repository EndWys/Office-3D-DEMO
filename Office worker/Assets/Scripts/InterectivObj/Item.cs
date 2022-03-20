using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public int underID;
    public int ID;
    GameObject PoiterArrow;
    SpriteRenderer ArrowSprite;
    GameObject[] intrectivObj;
    ObjScript obj;
    NeedIDscript needIDscript;
   // ReloadObj reloadObj;
    Vector3 PoinetPlace;
    private void Start()
    {
     
    }
    //public void FindTarget()
    //{
    //    //ArrowIS();
    //    //Debug.Log(ArrowSprite != null);
    //    ArrowSprite.enabled = true;
    //    for (int x = 0; x < intrectivObj.Length; x++)
    //    {
    //        //obj = intrectivObj[x].GetComponent<ObjScript>();
    //        needIDscript = intrectivObj[x].GetComponent<NeedIDscript>();
    //        if (needIDscript != null)
    //        {
    //            if (needIDscript.ItemID == ID && needIDscript.underIDneed == underID)
    //            {
    //                PoinetPlace = new Vector3(needIDscript.transform.position.x, needIDscript.transform.position.y + 3, needIDscript.transform.position.z);
    //                PoiterArrow.transform.position = PoinetPlace;
    //                break;
    //            }
    //        }
    //    }
        //ArrowSprite.enabled = true;
   // }
    //public void Droped()
    //{
    //    //PoiterArrow.SetActive(false);
    //    ArrowSprite.enabled = false;
    //    //Debug.Log("drop");
    //}
    //void ArrowIS()
    //{
    //    PoiterArrow = GameObject.Find("Arrow");
    //    intrectivObj = GameObject.FindGameObjectsWithTag("ActionObj");
    //    ArrowSprite = PoiterArrow.GetComponent<SpriteRenderer>();
    //    //Debug.Log(ArrowSprite != null);
    //}
}
   
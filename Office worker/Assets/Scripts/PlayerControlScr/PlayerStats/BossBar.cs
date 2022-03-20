using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBar : MonoBehaviour {
    GameMasterScript gameMaster;
    TextMesh txtBoss;
    public int angry;
	// Use this for initialization
	void Start () {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        txtBoss = GetComponent<TextMesh>();

    }
	
	// Update is called once per frame
	void Update () {
        txtBoss.text ="Boss:"+ angry + "/10";
        if (angry >= 10)
        {
            gameMaster.Lose();
        }
    }
    public void PlusOneAngry()
    {
        if(!gameMaster.win && !gameMaster.lose)
            angry++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    GameMasterScript gameMaster;
    TextMesh timerT;
    public float time;
    string timeText;

    // Use this for initialization
    void Start () {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        timerT = GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameMaster.win&& !gameMaster.lose) {
            time -= Time.deltaTime;
            timeText = time % 60 == 0 ?
            timeText = (time / 60) + ":" + "00" : (int)time % 60 >= 10 ?
            timeText = ((int)time / 60) + ":" + ((int)time % 60) : timeText = ((int)time / 60) + ":" + "0" + ((int)time % 60);
            timerT.text = "Time: " + timeText;
            if (time <= 0)
            {
                gameMaster.Win();
            }
        }
        //Debug.Log(time % 60);
    }
}

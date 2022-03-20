using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNum : MonoBehaviour
{
    PlayButton playButton;
    public int daynum;
    private void Start()
    {
        playButton = GameObject.Find("Interface").GetComponent<PlayButton>();
    }
    public void setLevelnum()
    {
        playButton.levelNum = daynum;
    }

}

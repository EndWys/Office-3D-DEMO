using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterScript : MonoBehaviour
{
    public bool lose, win;
    Object interfaceS;
    public Transform window;
    // Start is called before the first frame update
    void Start()
    {
        //interfaceS = Resources.Load("InterFace");
        //Instantiate(interfaceS);
    }

    // Update is called once per frame
    void Update()
    {
        //if (lose|| win)
        //{
            window.localPosition = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 5);
        //}
    }
    public void Lose()
    {
        lose = true;
    }
    public void Win()
    {
        win = true;
    }
    public void Reload()
    {
        SceneManager.LoadScene(1);   
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}

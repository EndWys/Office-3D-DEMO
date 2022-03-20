using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    SceneNum sceneNum;
    public int levelNum;
    int DirectionMove=0;
    Vector3 target = new Vector3(0, 570, 0);
    private void Start()
    {

    }
    private void Update()
    {
        
        //transform.position = Vector3.MoveTowards(transform.position, target1, 400) * Time.deltaTime;
        if (DirectionMove == 1)
        {
            transform.position -= target * Time.deltaTime/60;
            //transform.position = Vector3.MoveTowards(transform.position, target1, 2)*Time.deltaTime;
            Debug.Log(DirectionMove);
            if (transform.localPosition.y < -570)
            {
                DirectionMove = 0;
                Debug.Log("d");
            }
        }
        if (DirectionMove == 2)
        {
            transform.position += target * Time.deltaTime / 50;
            if (transform.localPosition.y > 0)
                DirectionMove = 0;
        }
    }
    public void OpenDays()
    {
        DirectionMove = 1;
    }
    public void CloseDays()
    {
        DirectionMove = 2;
    }
    public void StartDay()
    {
        StartCoroutine(DayStart());
    }
    IEnumerator DayStart()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(levelNum); 
    }
}

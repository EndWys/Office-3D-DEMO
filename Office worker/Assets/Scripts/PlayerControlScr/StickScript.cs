using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Text))]
public class StickScript : MonoBehaviour , IPointerDownHandler,IPointerUpHandler,IDragHandler,IEventSystemHandler
{
    int speedForBuild=16;
    EventSystem ES;
    bool stickUse;
    RectTransform StickBG;
    RectTransform stick;
    Vector3 inputVector;
    public Walking player;
    Vector2 screnPoint;
    Camera cam;
    void Start()
    {
        StickBG = GetComponent<RectTransform>();
        stick = transform.GetChild(0).GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData ped)
    {
        screnPoint = ped.position;
        cam = ped.pressEventCamera;
        // if (RectTransformUtility.ScreenPointToLocalPointInRectangle(StickBG, ped.position, ped.pressEventCamera, out pos))
       
    }
    public void OnPointerDown(PointerEventData ped)
    {
        stickUse = true;
        screnPoint = ped.position;
        cam = ped.pressEventCamera;
    }
    
    public void OnPointerUp(PointerEventData ped)
    {
        stickUse = false;
        inputVector = Vector3.zero;
        stick.anchoredPosition = Vector3.zero;
        player.Move(Vector3.zero, 0);
    }
    private void Update()
    {
        if(stickUse)
        StickUse(screnPoint, cam);
    }
    void StickUse(Vector2 screenPoint,Camera cam)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(StickBG, screenPoint, cam, out pos))
        {
            //Debug.Log(pos);
            pos.x = (pos.x / StickBG.sizeDelta.x);
            pos.y = (pos.y / StickBG.sizeDelta.y);
            //Debug.Log(pos);
            inputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
           // Debug.Log(inputVector);
            stick.anchoredPosition = new Vector2(inputVector.x * (StickBG.sizeDelta.x / 3), inputVector.z * (StickBG.sizeDelta.y / 3));
            Vector3 moveDirection=new Vector3(inputVector.z,0, -inputVector.x);
            player.Move(moveDirection/50,30);
        }

    }
}

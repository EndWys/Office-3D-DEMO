using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour {
    Image buttonImage;
	// Use this for initialization
	void Start () {
        buttonImage = GetComponent<Image>();
        buttonImage.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void On()
    {
        buttonImage.enabled = true;
    }
    public void Off()
    {
        buttonImage.enabled = false;
    }
}

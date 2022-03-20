using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneoffObj : MonoBehaviour
{
    public float DoingTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UseObj()
    {
        Destroy(gameObject, DoingTime);
    }
}

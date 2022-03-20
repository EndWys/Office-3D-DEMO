using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCinterecy : MonoBehaviour
{
    ReloadObj RO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "ActionObj")
        {
            RO = other.GetComponent<ReloadObj>();
            if (RO != null)
            {
                RO.UseObj();
            }
        }
    }
}

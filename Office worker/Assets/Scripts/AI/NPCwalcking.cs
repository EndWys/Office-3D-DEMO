using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCwalcking : MonoBehaviour {
    Rigidbody rb;
    Vector3 direction;
    NavMeshAgent NPC;
    public int NPCpointNumber;
    GameObject[] npcPoint;
    Vector3[] targetPoint;
    void Start () {
        targetPoint = new Vector3[NPCpointNumber];
        npcPoint = GameObject.FindGameObjectsWithTag("NPCpoint");
        for (int x = 0; x < NPCpointNumber; x++)
            targetPoint[x] = npcPoint[x].transform.position;
        NPC = GetComponent<NavMeshAgent>();
        direction = targetPoint[Random.Range(0, NPCpointNumber)];
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
 
        MoveToPoint(direction, 4);
        if (NPC.remainingDistance < 0.5f)
        {
            direction = targetPoint[Random.Range(0, NPCpointNumber)];
            StopMoving(1);
        }
    }
    public void Collision(Vector3 direction)
    {
        //Debug.Log("is did");
        rb.AddForce(direction * 120, ForceMode.Acceleration);
        StopMoving(0.6f);
    }
    void StopMoving(float time_to_move)
    {
        NPC.isStopped = true;
        Invoke("ContinueMoving", time_to_move);
    }
    void ContinueMoving()
    {
        NPC.isStopped = false;
    }
    void MoveToPoint(Vector3 point,float speed)
    {
        NPC.destination = point;
    }
   
}

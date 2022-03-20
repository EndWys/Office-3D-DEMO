using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walking : MonoBehaviour {
    float Speed;
    BossBar bossBar;
    bool isStay;
    Rigidbody rb;
    Rigidbody WalckingObj;
    NavMeshAgent agent;
    Vector3 forceDirection;
    private void Awake()
    {
        Invoke("Find",0.2f);
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        //rb.AddForce(Vector3.left * 30, ForceMode.Acceleration);
    }
    void Find()
    {
        bossBar = GameObject.Find("BossBar").GetComponent<BossBar>();
    }
    public void Move(Vector3 direction,float speed)
    {
        if (!isStay&& speed>0) {
            agent.isStopped = false;
            agent.SetDestination(transform.position + direction * speed);
            Speed = direction.magnitude * speed;
            forceDirection = direction;
        }
        else 
        {
            agent.isStopped = true;
        }
        //Debug.Log(Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            TooMuchSpeed(0.4f,true, other.transform.position - transform.position, 2000,other);
        }
        if (other.gameObject.name == "WaterOnFloor")
        {
            TooMuchSpeed(0.3f, false, forceDirection, 6000, other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name== "conditioner")
        {
            rb.AddForce(other.transform.forward*18, ForceMode.Acceleration);
            agent.speed = 6;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "conditioner")
        {
            agent.speed = 12;
        }
    }
    void TooMuchSpeed(float speeed,bool npc,Vector3 direction,float forceMulti,Collider col)
    {
        //Debug.Log(Speed);
        if (Speed > speeed && !isStay)
        {
            Stay(1.5f);
            if (!npc)
            {
                //rb.AddForce(forceDirection * 1000, ForceMode.Acceleration);
                rb.AddForce(direction * forceMulti * 10, ForceMode.Acceleration);
            }
            else
            {
                bossBar.PlusOneAngry();
                col.GetComponent<NPCwalcking>().Collision(direction);
            }
        }
    }
    void ReturnWalk()
    {
        if (agent.isStopped)
            agent.isStopped = false;
        agent.destination = transform.position;
        isStay = false;
    }
    public void Stay(float timeToContinue)
    {
        agent.destination = transform.position;
        agent.isStopped = true;
        isStay = true;
        Invoke("ReturnWalk", timeToContinue);
    }
}

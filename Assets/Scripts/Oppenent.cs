using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class Oppenent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    private Vector3 startPosition;
    public GameObject speedBooster;
    private void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        OpponentAgent= GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Öldün bro Npc");
            //transform.position = startPosition;
        }
    }
}

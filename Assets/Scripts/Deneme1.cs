using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deneme1 : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public GameObject speedBooster;
    private Vector3 startPosition;
    void Start()
    {
        speedBooster.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = startPosition; //Öldükten sonra baþlangýç konumuna geri döner;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("speedBoost"))
        {
            StartCoroutine(Booster());
        }
    }

    IEnumerator Booster()
    {
        speedBooster.SetActive(true);        
        yield return new WaitForSeconds(2);
        speedBooster.SetActive(false);
    }
}

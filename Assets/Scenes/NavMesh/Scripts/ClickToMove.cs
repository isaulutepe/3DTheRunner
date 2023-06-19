using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //Kodu kullanca��m�z nesnelerde NavMeshAgent COmponenti ekli de�ilse kod otomatik eklesin diye bunu yazd�k. 
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit(); //Ekranda dokunudgumuz yeri alabilmek i�in tan�mlad�k.

    private void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            var ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction,out m_HitInfo))
            {
                m_Agent.destination = m_HitInfo.point;
            }
        }
    }
}

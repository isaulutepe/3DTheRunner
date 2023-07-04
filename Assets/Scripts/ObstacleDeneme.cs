using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeneme : MonoBehaviour
{

    public float speed = 1f;
    public float strengt = 2.5f;
    public float randomOfset;

    private void Start()
    {
        randomOfset = UnityEngine.Random.Range(-2.5f, 2.5f);
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed + randomOfset) * strengt;
        transform.position = pos;
    }
}

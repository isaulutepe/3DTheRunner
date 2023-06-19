using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimation : MonoBehaviour
{
    public float speed = 1;
    public float strength = 2.5f;

    private float randomOffset;

    private void Start()
    {
        randomOffset = Random.Range(-strength, strength);
    }
    private void Update()
    {
        Vector3 pos=transform.position;
        pos.x = Mathf.Sin(Time.time * speed * randomOffset)*strength;
        transform.position = pos;
    }
}

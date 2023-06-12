using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFallowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float sSpeed = 10.0f;
    public Vector3 distance;
    public Transform lookTarget;

    private void LateUpdate()
    {
        Vector3 distancePos = cameraTarget.position + distance; //Takip mesafesi
        Vector3 speedPos = Vector3.Lerp(transform.position, distancePos, sSpeed * Time.deltaTime); //Takip hýzý
        transform.position = speedPos;
        transform.LookAt(lookTarget.position);
    }

  
}

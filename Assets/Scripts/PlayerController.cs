using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    public float xSpeed; //X eksenindeki h�z�m�z� belirlemek i�in.
    public float limitX;
    private Animator anim;

    public GameObject speedBooster;

    private void Start()
    {
        anim= GetComponent<Animator>();
        speedBooster.SetActive(false);
    }

    private void Update()
    {
        SwipeCheck();
        if (runningSpeed <=0)
        {
            Debug.Log("Animasyonu durdur.");
            anim.SetTrigger("EndAnim");

        }
    }

    private void SwipeCheck()
    {
        float newX = 0;
        float touchXDelta = 0;

        //Dokunma kontrolu i�in.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) //Ekrana dokunuluyorsa ve parmak hareket ediyorsa.
        {
            // Debug.Log("Parmak hareketi var.");
            //  Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width); //X y�n�ndeki delta pozisyonunu verir.
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;

        }
        //Unity similasyon �zerinde g�rebilmek i�in.
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X"); //Input systemden gelen bir isimlendirmedir.
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX); //X pozisyonunu bir aral�kta se�mek i�in kullan�lan haz�r bir methottur.
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

   
}

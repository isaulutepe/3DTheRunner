using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    //Çarpýþma kontrollerinin yapýlacaðý script dosyasýdýr.

    public int score;
    public TextMeshProUGUI CoinText;
    public GameObject startPosition;
    public GameObject speedBoosterIcon;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("End"))
        {
            PlayerFinished();
            
        }
    }
    public void PlayerFinished()
    {
        GetComponent<PlayerController>().runningSpeed = 0f;
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Öldün bro");
            this.gameObject.transform.position=startPosition.transform.position;
            score = 0;

        }
    }
    public void AddCoin()
    {
        score++;
        CoinText.text="Score: "+score.ToString();

    }

}

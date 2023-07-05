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
        if (other.gameObject.CompareTag("speedBoost"))
        {
            StartCoroutine(Booster());
        }
        if (other.gameObject.CompareTag("slowDown"))
        {
            StartCoroutine(slowDown());
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
    IEnumerator Booster()
    {
        GetComponent<PlayerController>().speedBooster.SetActive(true);
        GetComponent<PlayerController>().runningSpeed=8;
        yield return new WaitForSeconds(4);
        GetComponent<PlayerController>().speedBooster.SetActive(false);
        GetComponent<PlayerController>().runningSpeed=5;
    }
    IEnumerator slowDown() //Yavaþlatma bloklarýna girerse.
    {
        GetComponent<PlayerController>().runningSpeed = 3;
        yield return new WaitForSeconds(2);
        GetComponent<PlayerController>().runningSpeed = 5;
    }

}

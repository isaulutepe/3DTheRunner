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
    private InGameRanking ig;
    public GameObject gameOverPanel;
    private void Start()
    {
        ig = FindObjectOfType<InGameRanking>();
        gameOverPanel.SetActive(false); //Oyun bitti ekraný
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("End"))
        {
            PlayerFinished();
            if (ig.namestxt[6].text == "Player")
            {
                Debug.Log("Tebrikler");
            }
            else
            {
                Debug.Log("Loser");
            }

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
        //Animasoynu beklemesi lazým onun için 2 saniye wwait verdim.
        StartCoroutine(WaitForSecond());
       


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            this.gameObject.transform.position = startPosition.transform.position;
            score = 0;

        }
    }
    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();

    }
    IEnumerator Booster()
    {
        GetComponent<PlayerController>().speedBooster.SetActive(true);
        GetComponent<PlayerController>().runningSpeed = 8;
        yield return new WaitForSeconds(4);
        GetComponent<PlayerController>().speedBooster.SetActive(false);
        GetComponent<PlayerController>().runningSpeed = 5;
    }
    IEnumerator slowDown() //Yavaþlatma bloklarýna girerse.
    {
        GetComponent<PlayerController>().runningSpeed = 3;
        yield return new WaitForSeconds(2);
        GetComponent<PlayerController>().runningSpeed = 5;
    }
    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(2);
        gameOverPanel.SetActive(true); //Oyun bitti 
    }
}

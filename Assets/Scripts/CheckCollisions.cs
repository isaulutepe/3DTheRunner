using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    //�arp��ma kontrollerinin yap�laca�� script dosyas�d�r.

    public int score;
    public TextMeshProUGUI CoinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("�ld�n bro");
        }
    }
    public void AddCoin()
    {
        score++;
        CoinText.text="Score: "+score.ToString();

    }

}

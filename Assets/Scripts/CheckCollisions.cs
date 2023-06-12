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

    public void AddCoin()
    {
        score++;
        CoinText.text="Score: "+score.ToString();

    }

}

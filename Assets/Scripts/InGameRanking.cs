using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InGameRanking : MonoBehaviour
{
    public Text[] namestxt;
    public string a, b, c, d, e, f,g; //her bot ve player nesnesi için bir deðer tanýmlamasý yapýldý.
    private void Update()
    {
        namestxt[0].text = a;
        namestxt[1].text = b;
        namestxt[2].text = c;
        namestxt[3].text = d;
        namestxt[4].text = e;
        namestxt[5].text = f;
        namestxt[6].text = g;

    }
}

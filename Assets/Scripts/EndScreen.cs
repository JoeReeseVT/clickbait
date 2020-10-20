
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public GameObject Endscrn;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finalTime;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Endscrn.gameObject.SetActive(true);
            finalTime.text = timerText.text.Substring(6);
        }
    }
}

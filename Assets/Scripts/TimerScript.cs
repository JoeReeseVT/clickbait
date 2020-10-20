using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Math;

public class TimerScript : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    int intTime;
    private double time = 0;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        intTime = (int)time;

        timerText.text = "Time: " + intTime.ToString();
    }
}

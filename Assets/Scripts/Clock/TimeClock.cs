using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeClock : MonoBehaviour
{
    public delegate void TimePassDelegate(bool isDay, int currentHour, int currentMinute);
    public static TimePassDelegate timePass;

    public GameObject clockTextobject;
    TextMeshProUGUI clockText;
    public GameObject isDayTextObject;
    TextMeshProUGUI isDayText;

    public int dayLength = 12;
    public int nightLength = 6;
    public bool isDay = true;

    public float hourLength = 60f;
    public int currentHour;
    public float minuteLength = 60f;
    public int currentMinute;

    float currentTimeSeconds = 0;

    private void Awake()
    {
        clockText = clockTextobject.GetComponent<TextMeshProUGUI>();
        isDayText = isDayTextObject.GetComponent<TextMeshProUGUI>();

        clockText.text = $"{currentHour}:0{currentMinute}";
        if(isDay)
        {
            isDayText.text = "Daytime";
        }
        else
        {
            isDayText.text = "Nighttime";
        }
    }

    private void Update()
    {
        if(currentTimeSeconds < minuteLength)
        {
            currentTimeSeconds += Time.deltaTime;
        }
        else if(currentTimeSeconds >= minuteLength)
        {
            currentTimeSeconds = 0;
            currentMinute += 1;
            if(currentMinute < 10)
            {
                clockText.text = $"{currentHour}:0{currentMinute}";
            }
            else
            {
                clockText.text = $"{currentHour}:{currentMinute}";
            }

            if(currentMinute >= hourLength)
            {
                currentMinute = 0;
                currentHour += 1;
                if(currentHour >= dayLength && isDay)
                {
                    currentHour = 0;
                    isDay = false;
                    isDayText.text = "Nighttime";
                }
                else if(currentHour >= nightLength && !isDay)
                {
                    currentHour = 0;
                    isDay = true;
                    isDayText.text = "Daytime";
                }
            }
            timePass?.Invoke(isDay, currentHour, currentMinute);
        }
    }
}

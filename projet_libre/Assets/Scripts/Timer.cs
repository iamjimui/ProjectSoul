using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public TMP_Text timeText;
    public static bool timerOn = false;
    public static float timer = 0.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
            UpdateTimer(timer);
        }
    }

    void UpdateTimer(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.SetText(string.Format("{0:00} : {1:00}", minutes, seconds));
    }
}

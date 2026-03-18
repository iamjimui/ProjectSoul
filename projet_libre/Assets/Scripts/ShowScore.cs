using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TMP_Text scoreTimeText;
    // Start is called before the first frame update
    void Start()
    {
        float minutes = Mathf.FloorToInt(Timer.timer / 60);
        float seconds = Mathf.FloorToInt(Timer.timer % 60);

        scoreTimeText.SetText(string.Format("Score : {0:00} : {1:00}", minutes, seconds));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

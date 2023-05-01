using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    TextMeshProUGUI timeText;
    [SerializeField] TimerController timerController;
    string timePlayingString;

    private void Awake() 
    {
        timeText = GetComponent<TextMeshProUGUI>();    
    }
    private void Update() 
    {
        timePlayingString = "Time: " + timerController.timePlaying.ToString("mm':'ss'.'ff");
        timeText.text = timerController.timeCounter.text;
    }
}

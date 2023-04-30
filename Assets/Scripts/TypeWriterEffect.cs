using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] float delay = 0.05f;
    public string fullText;
    TextMeshProUGUI text;
    AudioPlayer audioPlayer;
    string currentText = "";

    private void Awake() {
        text = GetComponentInChildren<TextMeshProUGUI>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    public void StartText() {
        audioPlayer.play();
        StartCoroutine(ShowText());
    }

    public void Clear() {
        text.text = "";
        audioPlayer.stop();
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        audioPlayer.stop();
    }
}

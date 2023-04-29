using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] float delay = 0.1f;
    public string fullText;
    TextMeshProUGUI text;
    public AudioSource audioSource;
    string currentText = "";

    private void Awake() {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void StartText() {
        audioSource.Play();
        StartCoroutine(ShowText());
    }

    public void Clear() {
        text.text = "";
        audioSource.Stop();
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        audioSource.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tannoy : MonoBehaviour
{
    AudioPlayer autioplayer;
    [SerializeField] float minDelay = 300f;
    [SerializeField] float maxDelay = 600f;
    [SerializeField] float delayTime = 300f;
    [SerializeField] float nextPlayTime;

    void Start()
    {
        nextPlayTime = Time.time + delayTime;
        autioplayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        if (Time.time > nextPlayTime) {
            delayTime = Random.Range(minDelay, maxDelay);
            nextPlayTime = Time.time + delayTime;

            autioplayer.pickAndPlayNewSound();
        }
    }
}

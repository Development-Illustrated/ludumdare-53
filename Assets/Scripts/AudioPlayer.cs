using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] bool debugMode = false;
    [SerializeField] float pitch = 1f;
    [SerializeField] bool randomizePitch = false;
    [SerializeField] float minRandomPitch = 0.7f;
    [SerializeField] float maxRandomPitch = 1.4f;
    [SerializeField] float volume = 1f;
    
    AudioSource audioSource;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = getRandomAudioClip();
        if(randomizePitch)
        {
            pitch = Random.Range(minRandomPitch, maxRandomPitch);
        }
        audioSource.pitch = pitch;
        audioSource.volume = volume;
    }

    AudioClip getRandomAudioClip()
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        return audioClips[randomIndex];
    }

    public void play()
    {
        audioSource.Play();
    }

    public void pickAndPlayNewSound()
    {
        audioSource.clip = getRandomAudioClip();
        play();
    }

    public void stop()
    {
        audioSource.Stop();
    }

    public void playRandomOneShot()
    {
        AudioClip clip = getRandomAudioClip();
        if(debugMode){Debug.Log("Playing " + clip.name);}
        audioSource.PlayOneShot(clip);
    }
}

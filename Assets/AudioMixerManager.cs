using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    public AudioMixerGroup NormalAudioMixer;
    public AudioMixerGroup AdaptedAudioMixer;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    public void SetNormalAudioMixer()
    {
        audioSource.outputAudioMixerGroup = NormalAudioMixer;
    }

    public void SetAdaptedAudioMixer()
    {
        audioSource.outputAudioMixerGroup = AdaptedAudioMixer;
    }

    private void OnLevelWasLoaded(int level)
    {
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }
}

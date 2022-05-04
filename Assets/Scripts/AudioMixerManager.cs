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
        GetAudioSource();
    }

    private void GetAudioSource()
    {
        if (audioSource != null)
            return;
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    public void SetNormalAudioMixer()
    {
        GetAudioSource();
        audioSource.outputAudioMixerGroup = NormalAudioMixer;
    }

    public void SetAdaptedAudioMixer()
    {
        GetAudioSource();
        audioSource.outputAudioMixerGroup = AdaptedAudioMixer;
    }

    private void OnLevelWasLoaded(int level)
    {
        GetAudioSource();
    }
}

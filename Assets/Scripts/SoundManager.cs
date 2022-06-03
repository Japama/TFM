using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{



    public static AudioClip deathSound, jumpSound, victorySound, hitSound, fallSound, spawnSound, dashSound, ememyHitted;
    static AudioSource audioSourceClip;
    static AudioSource audioSourceMusic;
    public static AudioMixerGroup NormalMixer;
    public static AudioMixerGroup AdaptationMixer;

    public AudioClip[] MusicSections;
    // Music files which share the identifier 'Section' go in here. Example track: 'Adventure Inn Section 2.wav'.
    // In the editor, changing the 'Size' of the array increases/decreases the available slots. This is useful for removing unwanted music sections.
    public bool playIntro = true;
    // Disabling this in the Unity Inspector will skip Element 1 in MusicSections Array (by default this should be reserved for files with the 'Intro' identifier. Example track: 'Adventure Inn Section 1 Intro.wav').

    // The audiosource is responsible for playing all of our 'MusicSections'.
    private int lastPlayed;
    // This keeps a log of the last played music section. Leave this alone unless you know what you are doing!
    private bool preloadBufferActive = true;
    // Necessary Preload buffer, leave this alone unless you know what you are doing!

    // Start is called before the first frame update
    void Start()
    {
        deathSound = Resources.Load<AudioClip>("Hit");
        jumpSound = Resources.Load<AudioClip>("Jump");
        fallSound= Resources.Load<AudioClip>("Fall_short");
        dashSound = Resources.Load<AudioClip>("Dash");
        victorySound = Resources.Load<AudioClip>("Victory");
        ememyHitted = Resources.Load<AudioClip>("EmemyHitted");

        audioSourceMusic = GetComponents<AudioSource>().ToList().FirstOrDefault();
        audioSourceClip = GetComponents<AudioSource>().ToList().LastOrDefault();

        if (MusicSections.Length == 0)
        {
            Debug.Log("Please add music segments!");
            // If you see this message, please check to see if you have music sections loaded!
        }
        else
        {
            StartCoroutine(PlayAudio());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetAdaptationAudioMixer() => audioSourceClip.outputAudioMixerGroup = AdaptationMixer;

    public static void SetNormalAudioMixer() => audioSourceClip.outputAudioMixerGroup = NormalMixer;


    public static void PlaySound (SoundsEnum clip)
    {   
        if(!AdaptacionesManager.AtenuarSonidos || (AdaptacionesManager.AtenuarSonidos && !audioSourceClip.isPlaying))
        switch (clip)
        {
            case SoundsEnum.Jump:
                audioSourceClip.PlayOneShot(jumpSound);
                break;
            case SoundsEnum.Fall:
                audioSourceClip.PlayOneShot(fallSound);
                break;
            case SoundsEnum.Dash:
                audioSourceClip.PlayOneShot(dashSound);
                break;
            case SoundsEnum.Hit:
                audioSourceClip.PlayOneShot(hitSound);
                break;
            case SoundsEnum.Victory:
                audioSourceClip.PlayOneShot(victorySound);
                break;
            case SoundsEnum.Death:
                audioSourceClip.PlayOneShot(deathSound);
                break;
            case SoundsEnum.Spawn:
                audioSourceClip.PlayOneShot(spawnSound);
                break;
            case SoundsEnum.EmemyHitted:
                audioSourceClip.PlayOneShot(ememyHitted);
                break;
            default:
                break;
        }
    }

    IEnumerator PlayAudio()
    {
        if (preloadBufferActive)
        {
            audioSourceClip.clip = MusicSections[0];
            audioSourceClip.Play();
            yield return new WaitForSeconds(MusicSections[0].length);
            preloadBufferActive = false;
        }
        if (playIntro)
        // This is always 'Element 1' and should be assigned to audio files with the 'Intro' identifier. Example track: 'Adventure Inn Section 1 Intro.wav').
        {
            audioSourceClip.clip = MusicSections[1];
            audioSourceClip.Play();

            Debug.Log("Playing clip: " + MusicSections[1]);
            // Displays the currently playing clip in the editor console.
            yield return new WaitForSeconds(MusicSections[1].length);
            // This tells us to wait for the duration of the audio clip before proceeding any further.
            playIntro = false;
            // Ensures the Intro only plays once!
        }

        int section = Random.Range(2, MusicSections.Length);
        // Random number generator used to determine which music section from the array to play next.

        if (section != lastPlayed)
        // Ensures we don't play the same section twice!
        {
            audioSourceClip.clip = MusicSections[section];
            audioSourceClip.Play();

            Debug.Log("Playing clip: " + MusicSections[section]);
            // Displays the currently playing clip in the editor console.
            yield return new WaitForSeconds(MusicSections[section].length);
            // This tells us to wait for the duration of the audio clip before proceeding any further.
            lastPlayed = section;

            StartCoroutine(PlayAudio());
            // This keeps us in our loop.
        }
        else
        {
            StartCoroutine(PlayAudio());
            // This keeps us in our loop.
        }
    }
}

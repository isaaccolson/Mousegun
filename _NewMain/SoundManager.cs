using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource playerFxSource;
    public AudioSource[] musicSource;
    public static SoundManager instance = null;
    public AudioClip startingMusic;
    float lowPitchRange = .95f;
    float highPitchRange = 1.05f;
    float fadeInTime = 1.0f;
    float fadeOutTime = 1.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            StartSong(startingMusic);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartSong(AudioClip clip)
    {
        musicSource[0].clip = clip;
        musicSource[0].Play();
    }

    public void PlaySingle(AudioClip clip, bool isPlayer)
    {
        if (isPlayer)
        {
            playerFxSource.clip = clip;
            playerFxSource.Play();
        }
        else
        {
            efxSource.clip = clip;
            efxSource.Play();

        }
    }

    public void RandomizeSfx(AudioClip[] clips, bool isPlayer)
    {

        if (isPlayer)
        {
            playerFxSource.clip = clips[Random.Range(0, clips.Length)];
            playerFxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
            playerFxSource.Play();
        }
        else
        {

            efxSource.clip = clips[Random.Range(0, clips.Length)];
            efxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.Play();

        }

    }

    public void CrossFade(AudioClip _crossClip)
    {
        var canCrossFade = false;

        foreach (var source in musicSource)
        {
            if (!source.isPlaying)
            {
                canCrossFade = true;
                break;
            }
        }

        if (canCrossFade)
        {
            StartCoroutine(FadeOut());
            StartCoroutine(FadeIn(_crossClip));
        }

    }
    public IEnumerator FadeOut()
    {
        AudioSource currentMusic = null;

        foreach (var source in musicSource)
        {
            if (source.isPlaying)
            {
                currentMusic = source;
                break;
            }
        }

        float startVolume = currentMusic.volume;

        while (currentMusic.volume > 0)
        {
            currentMusic.volume -= startVolume * Time.deltaTime / fadeOutTime;
            yield return null;
        }
        currentMusic.Stop();
    }
    public IEnumerator FadeIn(AudioClip _fadeInClip)
    {
        AudioSource currentMusic = null;

        foreach (var source in musicSource)
        {
            if (!source.isPlaying)
            {
                currentMusic = source;
                break;
            }
        }
        currentMusic.clip = _fadeInClip;
        currentMusic.Play();
        currentMusic.volume = 0f;

        while (currentMusic.volume < 1)
        {
            currentMusic.volume += Time.deltaTime / fadeInTime;
            yield return null;
        }
    }

}

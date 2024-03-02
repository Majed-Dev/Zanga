using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("----Music Source-----")]
    [SerializeField] AudioSource musicSource;
    [Header("----SFX Source----")]
    [SerializeField] AudioSource SFXSource;

    public AudioClip soundtrack;

    [Header("Player")]
    public AudioClip stepping;
    public AudioClip dash;
    public AudioClip attack;

    [Header("Axe")]
    public AudioClip Hit;
    public AudioClip damage;
    public AudioClip step;
    void Start()
    {
        musicSource.clip = soundtrack;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

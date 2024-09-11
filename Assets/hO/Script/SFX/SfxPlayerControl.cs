using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SfxPlayerControl : MonoBehaviour
{
    public static SfxPlayerControl instance;
    private AudioSource audioSource;
    public AudioClip correctSfx;
    public AudioClip worngSfx;
    public AudioClip clickSfx;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    public void PlayCorrect()
    {
        audioSource.PlayOneShot(correctSfx);

    }

    public void PlayWorng()
    {
        audioSource.PlayOneShot(worngSfx);

    }


    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSfx);

    }
}

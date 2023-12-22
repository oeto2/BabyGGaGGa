using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance = null;

    public AudioSource audioSource;

    //티모 웃음소리
    public AudioClip audio_Teemo;

    //롤 패배 소리
    public AudioClip audio_Defeat;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //효과음 재생
    public void PlayEffectSound(AudioClip _clip)
    {
        if (_clip != null)
        {
            //클립 변경
            audioSource.clip = _clip;
        }

        if (audioSource != null)
        {
            audioSource.Stop();

            //효과음 재생
            audioSource.PlayOneShot(_clip);
        }
    }
}

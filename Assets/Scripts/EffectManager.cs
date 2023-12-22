using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance = null;

    public AudioSource audioSource;

    //Ƽ�� �����Ҹ�
    public AudioClip audio_Teemo;

    //�� �й� �Ҹ�
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

    //ȿ���� ���
    public void PlayEffectSound(AudioClip _clip)
    {
        if (_clip != null)
        {
            //Ŭ�� ����
            audioSource.clip = _clip;
        }

        if (audioSource != null)
        {
            audioSource.Stop();

            //ȿ���� ���
            audioSource.PlayOneShot(_clip);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    public AudioSource audioSource;

    //�������1
    public AudioClip audio_BGM1;

    private void Start()
    {
        //�⺻ ����������� ����
        audioSource.clip = audio_BGM1;
        //������� ����
        audioSource.Play();
    }
}

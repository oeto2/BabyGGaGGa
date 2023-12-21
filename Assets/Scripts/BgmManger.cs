using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    public AudioSource audioSource;

    //배경음악1
    public AudioClip audio_BGM1;

    private void Start()
    {
        //기본 배경음악으로 설정
        audioSource.clip = audio_BGM1;
        //배경음악 실행
        audioSource.Play();
    }
}

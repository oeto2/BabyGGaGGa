using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBgmManager : MonoBehaviour
{
    //오디오 소스
    public AudioSource audioSource;

    //오디오 클립
    public AudioClip[] clip_Title;

    private void Start()
    {
        //배경음악 재생
        audioSource.clip = clip_Title[0];
        audioSource.Play();
    }
}

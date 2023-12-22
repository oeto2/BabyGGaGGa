using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //싱글톤 패턴
    public static SoundManager instance = null;

    //오디오 소스
    public AudioSource audioSource;

    //매치 효과음
    public AudioClip audio_Match;

    //플립 효과음
    public AudioClip audio_Flip;

    //티모 웃음소리
    public AudioClip audio_Teemo;

    //롤 패배 소리
    public AudioClip audio_Defeat;

    //게임 오버음악
    public AudioClip[] audio_GameOver;

    //게임 클리어 음악
    public AudioClip[] audio_GameClear;

    private void Start()
    {
        Debug.Log(3 % 4);
    }

    public void Awake()
    {
        //싱글톤
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

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetKeyDown(KeyCode.Z))
       // {
       //     //매치 음악 재생
       //     PlayMatchSound();
       // }
       
       //if(Input.GetKeyDown(KeyCode.D))
       // {
       //     //플립 효과음 재생
       //     PlayFlipSound();
       // }
    }

    //매치 효과음 재생
    public void PlayEffectSound(AudioClip _clip)
    {
        if(_clip != null)
        {
            //클립 변경
            audioSource.clip = _clip;
        }
        
        if(audioSource != null)
        {
            //효과음 재생
            audioSource.PlayOneShot(_clip);
        }
    }
}

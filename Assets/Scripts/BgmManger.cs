using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    public static BgmManger instance = null;

    public AudioSource audioSource;

    //배경음악
    public AudioClip[] audio_BGM;

    //게임 오버음악
    public AudioClip[] audio_GameOver;

    //게임 클리어 음악
    public AudioClip[] audio_GameClear;

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

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    SoundManager.instance.PlayEffectSound(SoundManager.instance.audio_GameOver[2]);
        //}
    }

    private void Start()
    {
        //기본 배경음악으로 설정
        if(audio_BGM[0] != null)
        {
            audioSource.clip = audio_BGM[0];
        }

        if (audioSource != null)
        {
            //배경음악 실행
            audioSource.Play();
        }
    }

    //배경음악 속도 변경 (-3 ~ 3)
    public void ChangeBGMSpeed(float _speed)
    {
        if(audioSource != null)
        {
            if(_speed <= 3 && _speed>= -3)
            {
                //설정값으로 속도 변경
                audioSource.pitch = _speed;
            }
        }
    }

    //배경음 재생
    public void PlayBGMSound(AudioClip _clip)
    {
        if (_clip != null)
        {
            //클립 변경
            audioSource.clip = _clip;
        }

        if (audioSource != null)
        {
            //효과음 재생
            audioSource.PlayOneShot(_clip);
        }
    }
}

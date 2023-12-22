using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    public static BgmManger instance = null;

    public AudioSource audioSource;

    //배경음악1
    public AudioClip audio_BGM1;

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
        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    ChangeFastBGM();
        //}
    }

    private void Start()
    {
        //기본 배경음악으로 설정
        audioSource.clip = audio_BGM1;
        
        if(audioSource != null)
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
}

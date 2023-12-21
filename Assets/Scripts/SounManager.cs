using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounManager : MonoBehaviour
{
    //싱글톤 패턴
    public static SounManager instance = null;

    //오디오 소스
    public AudioSource audioSource;

    //매치 효과음
    public AudioClip audio_Match;

    //플립 효과음
    public AudioClip auido_Flip;

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
    public void PlayMatchSound()
    {
        //클립 변경
        audioSource.clip = audio_Match;
        
        if(audioSource != null)
        {
            //매치 효과음 재생
            audioSource.PlayOneShot(audio_Match);
        }
    }

    //카드 뒤집는 효과음 재생 
    public void PlayFlipSound()
    {
        //클립 변경
        audioSource.clip = auido_Flip;

        if(audioSource != null)
        {
            //플립 효과음 재생
            audioSource.PlayOneShot(auido_Flip);
        }
    }
}

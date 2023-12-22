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

    //클릭 소리
    public AudioClip[] audio_Click;

    //인포매니저 스크립트
    public InfoManager infoManagerScr;

    private void Start()
    {
        //인포 매니저 스크립트 할당
        GameObject infoObj = GameObject.Find("InfoManager");
        if (infoObj != null)
        {
            if (infoObj.GetComponent<InfoManager>() != null)
            {
                infoManagerScr = GameObject.Find("InfoManager").GetComponent<InfoManager>();
                //볼륨 조절
                audioSource.volume = infoManagerScr.effectValume;
            }
        }
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

    //효과음 재생
    public void PlayEffectSound(AudioClip _clip)
    {

        if(_clip != null)
        {
            //클립 변경
            audioSource.clip = _clip;
        }
        
        if(audioSource != null)
        {
            audioSource.Stop();

            //효과음 재생
            audioSource.PlayOneShot(_clip);
        }
    }
}

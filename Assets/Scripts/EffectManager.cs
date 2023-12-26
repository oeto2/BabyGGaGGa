using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance = null;

    public AudioSource audioSource;

    //티모 웃음소리
    public AudioClip audio_Teemo;

    //롤 패배 소리
    public AudioClip audio_Defeat;

    //인포매니저 스크립트
    public InfoManager infoManagerScr;

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

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    SceneManager.LoadScene("StartScene");
        //}
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

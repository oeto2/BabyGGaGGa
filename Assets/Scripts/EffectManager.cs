using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance = null;

    public AudioSource audioSource;

    //Ƽ�� �����Ҹ�
    public AudioClip audio_Teemo;

    //�� �й� �Ҹ�
    public AudioClip audio_Defeat;

    //�����Ŵ��� ��ũ��Ʈ
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
        //���� �Ŵ��� ��ũ��Ʈ �Ҵ�
        GameObject infoObj = GameObject.Find("InfoManager");
        if (infoObj != null)
        {
            if (infoObj.GetComponent<InfoManager>() != null)
            {
                infoManagerScr = GameObject.Find("InfoManager").GetComponent<InfoManager>();
                //���� ����
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

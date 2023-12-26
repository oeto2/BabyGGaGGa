using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    public static BgmManger instance = null;

    public AudioSource audioSource;

    //�������
    public AudioClip[] audio_BGM;

    //���� ��������
    public AudioClip[] audio_GameOver;

    //���� Ŭ���� ����
    public AudioClip[] audio_GameClear;

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
        //�⺻ ����������� ����
        if(audio_BGM[0] != null)
        {
            audioSource.clip = audio_BGM[0];
        }

        if (audioSource != null)
        {
            //������� ����
            audioSource.Play();
        }

        
        //���� �Ŵ��� ��ũ��Ʈ �Ҵ�
        GameObject infoObj = GameObject.Find("InfoManager");
        if(infoObj != null)
        {
            if (infoObj.GetComponent<InfoManager>() != null)
            {
                infoManagerScr = GameObject.Find("InfoManager").GetComponent<InfoManager>();
                //���� ����
                audioSource.volume = infoManagerScr.bgmValume;
            }
        }
    }

    //������� �ӵ� ���� (-3 ~ 3)
    public void ChangeBGMSpeed(float _speed)
    {
        if(audioSource != null)
        {
            if(_speed <= 3 && _speed>= -3)
            {
                //���������� �ӵ� ����
                audioSource.pitch = _speed;
            }
        }
    }

    //����� ���
    public void PlayBGMSound(AudioClip _clip)
    {
        if (_clip != null)
        {
            //Ŭ�� ����
            audioSource.clip = _clip;
        }

        if (audioSource != null)
        {
            //ȿ���� ���
            audioSource.PlayOneShot(_clip);
        }
    }
}

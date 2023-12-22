using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    public static BgmManger instance = null;

    public AudioSource audioSource;

    //�������
    public AudioClip[] audio_BGM;

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
}

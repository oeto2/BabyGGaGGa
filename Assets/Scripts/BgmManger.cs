using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManger : MonoBehaviour
{
    public static BgmManger instance = null;

    public AudioSource audioSource;

    //�������1
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
        //�⺻ ����������� ����
        audioSource.clip = audio_BGM1;
        
        if(audioSource != null)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //�̱��� ����
    public static SoundManager instance = null;

    //����� �ҽ�
    public AudioSource audioSource;

    //��ġ ȿ����
    public AudioClip audio_Match;

    //�ø� ȿ����
    public AudioClip audio_Flip;

    //Ƽ�� �����Ҹ�
    public AudioClip audio_Teemo;

    //�� �й� �Ҹ�
    public AudioClip audio_Defeat;

    //���� ��������
    public AudioClip[] audio_GameOver;

    //���� Ŭ���� ����
    public AudioClip[] audio_GameClear;

    private void Start()
    {
        Debug.Log(3 % 4);
    }

    public void Awake()
    {
        //�̱���
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
       //     //��ġ ���� ���
       //     PlayMatchSound();
       // }
       
       //if(Input.GetKeyDown(KeyCode.D))
       // {
       //     //�ø� ȿ���� ���
       //     PlayFlipSound();
       // }
    }

    //��ġ ȿ���� ���
    public void PlayEffectSound(AudioClip _clip)
    {
        if(_clip != null)
        {
            //Ŭ�� ����
            audioSource.clip = _clip;
        }
        
        if(audioSource != null)
        {
            //ȿ���� ���
            audioSource.PlayOneShot(_clip);
        }
    }
}

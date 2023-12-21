using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounManager : MonoBehaviour
{
    //�̱��� ����
    public static SounManager instance = null;

    //����� �ҽ�
    public AudioSource audioSource;

    //��ġ ȿ����
    public AudioClip audio_Match;

    //�ø� ȿ����
    public AudioClip auido_Flip;

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
    public void PlayMatchSound()
    {
        //Ŭ�� ����
        audioSource.clip = audio_Match;
        
        if(audioSource != null)
        {
            //��ġ ȿ���� ���
            audioSource.PlayOneShot(audio_Match);
        }
    }

    //ī�� ������ ȿ���� ��� 
    public void PlayFlipSound()
    {
        //Ŭ�� ����
        audioSource.clip = auido_Flip;

        if(audioSource != null)
        {
            //�ø� ȿ���� ���
            audioSource.PlayOneShot(auido_Flip);
        }
    }
}

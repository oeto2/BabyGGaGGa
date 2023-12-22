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

    //Ŭ�� �Ҹ�
    public AudioClip[] audio_Click;
  

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

    //ȿ���� ���
    public void PlayEffectSound(AudioClip _clip)
    {

        if(_clip != null)
        {
            //Ŭ�� ����
            audioSource.clip = _clip;
        }
        
        if(audioSource != null)
        {
            audioSource.Stop();

            //ȿ���� ���
            audioSource.PlayOneShot(_clip);
        }
    }
}

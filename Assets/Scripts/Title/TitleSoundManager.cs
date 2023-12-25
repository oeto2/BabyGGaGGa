using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
    //�̱���
    public static TitleSoundManager instance = null;

    //����� �ҽ�
    public AudioSource audioSource;

    //Ŭ�� ȿ����
    public AudioClip[] clip_Click;

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

    //��ư Ŭ�� ȿ���� ���
    public void PlayButtonClick(AudioClip _clip)
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
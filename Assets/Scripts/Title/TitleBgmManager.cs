using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBgmManager : MonoBehaviour
{
    //����� �ҽ�
    public AudioSource audioSource;

    //����� Ŭ��
    public AudioClip[] clip_Title;

    private void Start()
    {
        //������� ���
        audioSource.clip = clip_Title[0];
        audioSource.Play();
    }
}

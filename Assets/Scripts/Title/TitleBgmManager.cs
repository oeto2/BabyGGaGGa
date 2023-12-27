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

    public void SetbgmVolume(float volume)
    {
        audioSource.volume = volume;
        InfoManager.instance.bgmValume = volume;
        if (audioSource.volume == 0f)
        {
            GameObject.Find("Canvas/optionCanvas/bgm/ImageOn").gameObject.SetActive(false);
            GameObject.Find("Canvas/optionCanvas/bgm/ImageOff").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas/optionCanvas/bgm/ImageOn").gameObject.SetActive(true);
            GameObject.Find("Canvas/optionCanvas/bgm/ImageOff").gameObject.SetActive(false);
        }
    }

}

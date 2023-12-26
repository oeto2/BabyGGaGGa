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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ShopManager.instance.ShowShop();
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

    public void SeteffectValume(float volume)
    {
        audioSource.volume = volume;
        InfoManager.instance.effectValume = volume;
        if (audioSource.volume == 0f)
        {
            GameObject.Find("Canvas/optionPage/effectSliderImgOn").gameObject.SetActive(false);
            GameObject.Find("Canvas/optionPage/effectSliderImgOff").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas/optionPage/effectSliderImgOn").gameObject.SetActive(true);
            GameObject.Find("Canvas/optionPage/effectSliderImgOff").gameObject.SetActive(false);
        }
    }
}

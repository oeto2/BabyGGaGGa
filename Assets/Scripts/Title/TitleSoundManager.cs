using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
    //싱글톤
    public static TitleSoundManager instance = null;

    //오디오 소스
    public AudioSource audioSource;

    //클릭 효과음
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

    //버튼 클릭 효과음 재생
    public void PlayButtonClick(AudioClip _clip)
    {
        if (_clip != null)
        {
            //클립 변경
            audioSource.clip = _clip;
        }

        if (audioSource != null)
        {
            audioSource.Stop();

            //효과음 재생
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnlockInfo
{
    //해금할 멤버 
    public bool cch1 = false;
    public bool cch2 = false;
    public bool pjh1 = false;
    public bool pjh2 = false;
    public bool yjh1 = false;
    public bool yjh2 = false;
    public bool lsm1 = false;
    public bool lsm2 = false;
    public bool ljh1 = false;
    public bool ljh2 = false;
}

public class InfoManager : MonoBehaviour
{
    //싱글톤
    public static InfoManager instance = null;

    //배경음 크기
    public float bgmValume = 1f;

    //효과음 크기
    public float effectValume = 1f;

    //난이도
    public int int_level = 0;

    //멤버 정보값 클래스
    public UnlockInfo unlockInfo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            unlockInfo.cch1 = true;
        }
    }
}
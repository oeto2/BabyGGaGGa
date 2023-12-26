using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfoManager : MonoBehaviour
{
    //싱글톤
    public static InfoManager instance = null;

    //배경음 크기
    [Range(0.1f, 1f)] public float bgmValume = 1f;

    //효과음 크기
    [Range(0.1f, 1f)] public float effectValume = 1f;

    //난이도
    public int int_level = 0;

    //멤버 정보값 배열
    public bool[] unlockInfo = new bool[9];

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
}
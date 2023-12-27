using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public bool[] unlockInfo = new bool[10];

    //현재 소지 골드
    public int int_CurGold = 0;

    public bool isPageOpen = false;

    //현재 선택된 폰트
    public int int_CurFontNum = 0;

    //UpGrade Level
    public int timeUpLevel = 1;
    public int scoreUpLevel = 1;
    public int comboUpLevel = 1;


    //UpGrade Cost
    public int timeUpCost = 100;
    public int scoreUpCost = 100;
    public int comboUpCost = 100;

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

    //골드 획득
    public void AddGold(int _value)
    {
        //골드 추가
        int_CurGold += _value;
    }
}
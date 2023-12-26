using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoManager : MonoBehaviour
{
    //½Ì±ÛÅæ
    public static InfoManager instance = null;

    //¹è°æÀ½ Å©±â
    [Range(0.1f, 1f)] public float bgmValume = 1f;

    //È¿°úÀ½ Å©±â
    [Range(0.1f, 1f)] public float effectValume = 1f;

    //³­ÀÌµµ
    public int int_level = 0;

    //¸â¹ö Á¤º¸°ª ¹è¿­
    public bool[] unlockInfo = new bool[10];

    //ÇöÀç ¼ÒÁö °ñµå
    public int int_CurGold = 0;

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

    //°ñµå È¹µæ
    public void AddGold(int _value)
    {
        //°ñµå Ãß°¡
        int_CurGold += _value;
    }
}
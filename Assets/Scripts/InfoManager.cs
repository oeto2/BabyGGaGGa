using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoManager : MonoBehaviour
{
    //�̱���
    public static InfoManager instance = null;

    //����� ũ��
    [Range(0.1f, 1f)] public float bgmValume = 1f;

    //ȿ���� ũ��
    [Range(0.1f, 1f)] public float effectValume = 1f;

    //���̵�
    public int int_level = 0;

    //��� ������ �迭
    public bool[] unlockInfo = new bool[10];

    //���� ���� ���
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

    //��� ȹ��
    public void AddGold(int _value)
    {
        //��� �߰�
        int_CurGold += _value;
    }
}
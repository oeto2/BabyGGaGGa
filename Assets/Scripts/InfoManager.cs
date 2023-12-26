using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
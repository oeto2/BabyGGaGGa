using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnlockInfo
{
    //�ر��� ��� 
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
    //�̱���
    public static InfoManager instance = null;

    //����� ũ��
    [Range(0.1f, 1f)] public float bgmValume = 1f;

    //ȿ���� ũ��
    [Range(0.1f, 1f)] public float effectValume = 1f;

    //���̵�
    public int int_level = 0;

    //��� ������ Ŭ����
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
    
    }
}
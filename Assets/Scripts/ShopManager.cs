using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    //�̱���
    public static ShopManager instance = null;

    //Shop Ui
    public GameObject obj_ShopUi;

    //Cur Gold_Text
    public Text text_CurGold;

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

    //���� UI Ȱ��ȭ
    public void ShowShop()
    {
        obj_ShopUi.SetActive(true);

        //UI Text ������Ʈ
        text_CurGold.text = ": " + InfoManager.instance.int_CurGold.ToString();
    }

    //���� UI �ݱ�
    public void CloseShop()
    {
        obj_ShopUi.SetActive(false);
    }
}

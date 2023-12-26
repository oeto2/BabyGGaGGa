using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    //싱글톤
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

    //상점 UI 활성화
    public void ShowShop()
    {
        obj_ShopUi.SetActive(true);

        //UI Text 업데이트
        text_CurGold.text = ": " + InfoManager.instance.int_CurGold.ToString();
    }

    //상점 UI 닫기
    public void CloseShop()
    {
        obj_ShopUi.SetActive(false);
    }
}

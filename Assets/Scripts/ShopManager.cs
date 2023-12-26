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

    //Level Text
    public Text text_TimeLevel;
    public Text text_ScoreLevel;
    public Text text_ComboLevel;

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

    //Upgrade Time
    public void UpgradeTimeButton_Click()
    {
        InfoManager.instance.timeUpLevel++;
        text_TimeLevel.text = "LV" + InfoManager.instance.timeUpLevel.ToString();
    }

    //Upgrade Score
    public void UpgradeScoreButton_Click()
    {
        InfoManager.instance.scoreUpLevel++;
        text_ScoreLevel.text = "LV" + InfoManager.instance.scoreUpLevel.ToString();
    }

    //Upgrade Combo
    public void UpgradeComboButton_Click()
    {
        InfoManager.instance.comboUpLevel++;
        text_ComboLevel.text = "LV" + InfoManager.instance.comboUpLevel.ToString();
    }
}

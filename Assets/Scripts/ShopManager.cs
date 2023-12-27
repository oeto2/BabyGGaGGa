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

    //Cost Text
    public Text text_TimeUpCost;
    public Text text_ScoreUpCost;
    public Text text_ComboUpCost;

    //Cost Value
    public int int_CostValue = 100;

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
        //������Ʈ Ȱ��ȭ
        obj_ShopUi.SetActive(true);

        //UI Text ������Ʈ
        text_CurGold.text = ": " + InfoManager.instance.int_CurGold.ToString();

        //Level Text ������Ʈ
        text_TimeLevel.text = "LV" + InfoManager.instance.timeUpLevel.ToString();
        text_ScoreLevel.text = "LV" + InfoManager.instance.scoreUpLevel.ToString();
        text_ComboLevel.text = "LV" + InfoManager.instance.comboUpLevel.ToString();

        //Cost Text ������Ʈ
        text_TimeUpCost.text = InfoManager.instance.timeUpCost.ToString();
        text_ScoreUpCost.text = InfoManager.instance.scoreUpCost.ToString();
        text_ComboUpCost.text = InfoManager.instance.comboUpCost.ToString();
    }

    //���� UI �ݱ�
    public void CloseShop()
    {
        obj_ShopUi.SetActive(false);
    }

    //Upgrade Time
    public void UpgradeTimeButton_Click()
    {
        //Time Upgrade Cost
        int int_Cost = InfoManager.instance.timeUpCost;

        //Use CurGold
        if (InfoManager.instance.int_CurGold < int_Cost)
        {
            Debug.Log("�������� �����մϴ�.");
        }
        else
        {
            //Level Up
            InfoManager.instance.timeUpLevel++;
            text_TimeLevel.text = "LV" + InfoManager.instance.timeUpLevel.ToString();

            //Cost Up
            InfoManager.instance.timeUpCost += int_CostValue;
            text_TimeUpCost.text = InfoManager.instance.timeUpCost.ToString();

            //�ݾ� ����
            InfoManager.instance.int_CurGold -= int_Cost;
            UpdateCurGold();
        }
    }

    //Upgrade Score
    public void UpgradeScoreButton_Click()
    {
        //Score Upgrade Cost
        int int_Cost = InfoManager.instance.scoreUpCost;

        //Use CurGold
        if (InfoManager.instance.int_CurGold < int_Cost)
        {
            Debug.Log("�������� �����մϴ�.");
        }
        else
        {
            //Level UP
            InfoManager.instance.scoreUpLevel++;
            text_ScoreLevel.text = "LV" + InfoManager.instance.scoreUpLevel.ToString();

            //Cost Up
            InfoManager.instance.scoreUpCost += int_CostValue;
            text_ScoreUpCost.text = InfoManager.instance.scoreUpCost.ToString();

            //�ݾ� ����
            InfoManager.instance.int_CurGold -= int_Cost;
            UpdateCurGold();
        }
    }

    //Upgrade Combo
    public void UpgradeComboButton_Click()
    {
        //Upgrade Cost
        int int_Cost = InfoManager.instance.comboUpCost;

        //Use CurGold
        if (InfoManager.instance.int_CurGold < int_Cost)
        {
            Debug.Log("�������� �����մϴ�.");
        }
        else
        {
            //Level UP
            InfoManager.instance.comboUpLevel++;
            text_ComboLevel.text = "LV" + InfoManager.instance.comboUpLevel.ToString();

            //Cost Up
            InfoManager.instance.comboUpCost += int_CostValue;
            text_ComboUpCost.text = InfoManager.instance.comboUpCost.ToString();

            //�ݾ� ����
            InfoManager.instance.int_CurGold -= int_Cost;
            UpdateCurGold();
        }
    }

    //������ ����
    public void UpdateCurGold()
    {
        text_CurGold.text = InfoManager.instance.int_CurGold.ToString();
    }

}

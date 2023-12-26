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

    //상점 UI 활성화
    public void ShowShop()
    {
        //오브젝트 활성화
        obj_ShopUi.SetActive(true);

        //UI Text 업데이트
        text_CurGold.text = ": " + InfoManager.instance.int_CurGold.ToString();

        //Level Text 업데이트
        text_TimeLevel.text = "LV" + InfoManager.instance.timeUpLevel.ToString();
        text_ScoreLevel.text = "LV" + InfoManager.instance.scoreUpLevel.ToString();
        text_ComboLevel.text = "LV" + InfoManager.instance.comboUpLevel.ToString();

        //Cost Text 업데이트
        text_TimeUpCost.text = InfoManager.instance.timeUpCost.ToString();
        text_ScoreUpCost.text = InfoManager.instance.scoreUpCost.ToString();
        text_ComboUpCost.text = InfoManager.instance.comboUpCost.ToString();
    }

    //상점 UI 닫기
    public void CloseShop()
    {
        obj_ShopUi.SetActive(false);
    }

    //Upgrade Time
    public void UpgradeTimeButton_Click()
    {
        //Level Up
        InfoManager.instance.timeUpLevel++;
        text_TimeLevel.text = "LV" + InfoManager.instance.timeUpLevel.ToString();

        //Cost Up
        InfoManager.instance.timeUpCost += int_CostValue;
        text_TimeUpCost.text = InfoManager.instance.timeUpCost.ToString();
    }

    //Upgrade Score
    public void UpgradeScoreButton_Click()
    {
        InfoManager.instance.scoreUpLevel++;
        text_ScoreLevel.text = "LV" + InfoManager.instance.scoreUpLevel.ToString();

        //Cost Up
        InfoManager.instance.scoreUpCost += int_CostValue;
        text_ScoreUpCost.text = InfoManager.instance.scoreUpCost.ToString();
    }

    //Upgrade Combo
    public void UpgradeComboButton_Click()
    {
        InfoManager.instance.comboUpLevel++;
        text_ComboLevel.text = "LV" + InfoManager.instance.comboUpLevel.ToString();

        //Cost Up
        InfoManager.instance.comboUpCost += int_CostValue;
        text_ComboUpCost.text = InfoManager.instance.comboUpCost.ToString();
    }
}

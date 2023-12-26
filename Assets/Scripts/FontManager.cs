using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using Unity.VisualScripting;



public class FontManager : MonoBehaviour
{
    //싱글톤 패턴
    public static FontManager instance = null;
    public Dropdown dropdown;

    //폰트 string 배열로 추가 하기 텍스트를 계속 추가하면 됨
    public string[] Fonts = {
        "Assets/Fonts/Ansungtangmyun-ESG.ttf",   //0.안성탕면ESG   
        "Assets/Fonts/BMHANNA_11yrs_ttf.ttf",    //1.BM한나
        "Assets/Fonts/ChosunCentennial_ttf.ttf", //2.조선센티널
        "Assets/Fonts/ChosunSm.TTF",             //3.조선SM
        "Assets/Fonts/CookieRun Black.ttf",      //4.쿠키런 블랙
        "Assets/Fonts/CookieRun Bold.ttf",       //5.쿠키런 볼드    
        "Assets/Fonts/CookieRun Regular.ttf",    //6.쿠키런 레쥴러
        "Assets/Fonts/Dovemayo_gothic.ttf",      //7.도베마요고딕
        "Assets/Fonts/Sejong hospital Bold.ttf", //8.세종호텔 볼드
        "Assets/Fonts/Sejong hospital Light.ttf" //9.세종호텔 라이트
    };
    
    void Start()
    {
        ChangeAllFonts(0);
    }

    
    public void Awake()
    {
        //싱글톤
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


    //모든 폰트 바꾸기
    public void ChangeAllFonts(int num)
    {
        var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

        foreach (Text t in allTextObjects)
        {
            t.font = AssetDatabase.LoadAssetAtPath<Font>(Fonts[num]);
        }

    }

}

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;



public class FontManager : MonoBehaviour
{
    //�̱��� ����
    public static FontManager instance = null;

    //��Ʈ string �迭�� �߰� �ϱ� �ؽ�Ʈ�� ��� �߰��ϸ� ��
    public string[] Fonts = {
        "Assets/Fonts/Ansungtangmyun-ESG.ttf",   //0.�ȼ�����ESG   
        "Assets/Fonts/BMHANNA_11yrs_ttf.ttf",    //1.BM�ѳ�
        "Assets/Fonts/ChosunCentennial_ttf.ttf", //2.������Ƽ��
        "Assets/Fonts/ChosunSm.TTF",             //3.����SM
        "Assets/Fonts/CookieRun Black.ttf",      //4.��Ű�� ��
        "Assets/Fonts/CookieRun Bold.ttf",       //5.��Ű�� ����    
        "Assets/Fonts/CookieRun Regular.ttf",    //6.��Ű�� ���췯
        "Assets/Fonts/Dovemayo_gothic.ttf",      //7.����������
        "Assets/Fonts/Sejong hospital Bold.ttf", //8.����ȣ�� ����
        "Assets/Fonts/Sejong hospital Light.ttf" //9.����ȣ�� ����Ʈ
    };
    public void Awake()
    {
        //�̱���
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

    
    //��� ��Ʈ �ٲٱ�
    public void ChangeAllFonts(int num)
    {
        var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

        foreach (Text t in allTextObjects)
        {
<<<<<<< Updated upstream
            t.font = AssetDatabase.LoadAssetAtPath<Font>(Fonts[num]); 
=======
            for (int i = 0; i > TextBox.Length; i++)
            {
                if (t != GameObject.Find("Canvas/optionPage/Dropdown/Dropdown List/Viewport/Content").GetComponentsInChildren<Text>()[i])
                {
                    t.font = AssetDatabase.LoadAssetAtPath<Font>(Fonts[num]);
                }
            }

>>>>>>> Stashed changes
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    static string nextScene;

    public GameObject completeText;

    [SerializeField]
    Image progressBar;

    public Text tooltip;

    string[] tooltips = {
    "연속으로 맞출 시 콤보 시스템이 작동합니다.",
    "카드 매칭이 틀리면 점수가 감소합니다.",
    "게임을하여 골드를 획득 할 수 있습니다.",
    "상점에서 능력치를 강화할 수 있습니다."
    };

    public static void LoadSceme(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        //FontManager.instance.SetAllFonts(InfoManager.instance.int_CurFontNum);
        StartCoroutine(LoadSeceneProcess());
        tooltip.text = tooltips[Random.Range(0, 4)];
    }

    // Update is called once per frame
    IEnumerator LoadSeceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        // 로딩을 90%까지 로딩하기
        op.allowSceneActivation = false;
        
        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)
                {
                    tooltip.gameObject.SetActive(false);
                    completeText.SetActive(true);
                }
                if(progressBar.fillAmount >= 1f && Input.GetMouseButtonDown(0))
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}

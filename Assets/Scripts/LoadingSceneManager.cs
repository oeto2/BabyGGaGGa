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
    "�������� ���� �� �޺� �ý����� �۵��մϴ�.",
    "ī�� ��Ī�� Ʋ���� ������ �����մϴ�.",
    "�������Ͽ� ��带 ȹ�� �� �� �ֽ��ϴ�.",
    "�������� �ɷ�ġ�� ��ȭ�� �� �ֽ��ϴ�."
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
        // �ε��� 90%���� �ε��ϱ�
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

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

    public static void LoadSceme(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSeceneProcess());
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

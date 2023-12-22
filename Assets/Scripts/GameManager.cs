using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Text timeText;
    public Text NameText;
    public GameObject endText;
    public GameObject card;
    float time = 60.0f;
    float item;

    public GameObject firstCard;
    public GameObject secondCard;

    public Animator txtAnim;


    public int matchCount;

    //초반에 클릭 못하게 막기 및 2개 확인후에 진행되게끔 변경
    public bool tryChance = false;

    Dictionary<GameObject, Vector3> cardList = new Dictionary<GameObject, Vector3>();
    int cardsLeft;
    private bool isCardGenerated;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }


    void Start()
    {
        //카드 생성
        GenerateCard();
        Time.timeScale = 1f;
        isCardGenerated = false;

        /*
        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
        cards = cards.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.7f;

            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "card" + cards[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
        */
    }
    // Update is called once per frame
    void Update()
    {


        //카드 배치
        if (isCardGenerated == false)
        {
            StartCoroutine(GenerateCardMoveToTarget(0.03f));
        }
        else
        {
            tryChance = true;
            //박지훈A님 코드
            time -= Time.deltaTime;
            timeText.text = time.ToString("N0");

            if (time <= 10.0f)
            {
                BgmManger.instance.ChangeBGMSpeed(1.3f);
                timeText.color = new Color(255, 0, 0, 255);
                txtAnim.SetBool("light", true);
            }

            //게임 오버
            if (time <= 0.0f)
            {
                GameEnd();
            }
        }
    }

    public void IsMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        tryChance = false;

        if (firstCardImage == secondCardImage)
        {
            

            firstCard.GetComponent<card>().DestroyCard();
            secondCard.GetComponent<card>().DestroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            SoundManager.instance.PlayEffectSound(SoundManager.instance.audio_Match);
            //윤재현님 코드
            switch (firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name)
            {
                case "card0": ShowNameText("최철민 팀장"); break;
                case "card1": ShowNameText("최철민 팀장"); break;
                case "card2": ShowNameText("박지훈A"); break;
                case "card3": ShowNameText("박지훈A"); break;
                case "card4": ShowNameText("윤재현"); break;
                case "card5": ShowNameText("윤재현"); break;
                case "card6": ShowNameText("이상민"); break;
                case "card7": ShowNameText("이상민"); break;
                case "card8": ShowNameText("이재헌"); break;
                case "card9": ShowNameText("이재헌"); break;
            }
            if (cardsLeft == 2)
            {
                //종료시키자!!
                BgmManger.instance.PlayBGMSound(BgmManger.instance.audio_GameClear[0]);
                Time.timeScale = 0f;
                endText.SetActive(true);
                //Invoke("GameEnd", 1f);
            }
        }
        else
        {
            EffectManager.instance.PlayEffectSound(EffectManager.instance.audio_Teemo);
            ShowNameText("실패");
            firstCard.GetComponent<card>().CloseCard();
            secondCard.GetComponent<card>().CloseCard();
        }
        matchCount++;
        firstCard = null;
        secondCard = null;
    }

    void ShowNameText(string name)
    {
        NameText.text = name;
        NameText.gameObject.SetActive(true);
        Invoke("HideNameText", 1f);
    }

    void HideNameText()
    {
        NameText.gameObject.SetActive(false);
    }

    void GameEnd()
    {
        EffectManager.instance.PlayEffectSound(EffectManager.instance.audio_Defeat);
        //종료시키자!!
        Time.timeScale = 0f;
        endText.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GenerateCard()
    {
        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        cards = cards.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        cardsLeft = cards.Length;

        for (int i = 0; i < 20; i++)
        {
            //게임 오브젝트 (각각의 요소)
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            //이재헌님 코드 
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.7f;
            newCard.transform.position = new Vector3(0f, 0f, 0f);

            //게임 오브젝트가 이동해야 할 좌표
            Vector3 target = new Vector3(x, y, 0);

            string rtanName = "card" + cards[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);

            //배열에 저장하기 (오브젝트, 오브젝트가 이동할 좌표)
            cardList.Add(newCard, target);
        }
    }

    IEnumerator GenerateCardMoveToTarget(float waitSeconds)
    {
        foreach (KeyValuePair<GameObject, Vector3> card in cardList)
        {
            GameObject cardGameObject = card.Key;
            Vector3 cardVector3 = card.Value;
            cardGameObject.transform.position = Vector3.Lerp(cardGameObject.transform.position, cardVector3, 0.1f);
            yield return new WaitForSeconds(waitSeconds);
        }
        isCardGenerated = true;
    }

}


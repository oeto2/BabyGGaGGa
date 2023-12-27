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
    new cameraShake camera;
    public float VibrateForTime = 0.2f;

    public Text timeText;
    public Text NameText;
    public GameObject StartText;
    public GameObject endText;

    public Text ComboEffect;

    public Text[] endTitleArrText;   // ���� ����� Ÿ��Ʋ

    public GameObject card;

    
    float time = 60.0f + (InfoManager.instance.timeUpLevel * 2);
    float item;

    int scorePower = 10 + (InfoManager.instance.scoreUpLevel - 1);
    int comboPower = 1 + InfoManager.instance.comboUpLevel;

    public GameObject firstCard;
    public GameObject secondCard;

    public Animator txtAnim;
    public Animator failAnim;


    public int matchCount;

    float checkTime = 0;

    bool isGameOver = false;
    //�ʹݿ� Ŭ�� ���ϰ� ���� �� 2�� Ȯ���Ŀ� ����ǰԲ� ����
    public bool tryChance = false;

    public int Maxcombo;
    public int combo;
    public Text[] scoreData;
    public int score = 0;
    public Text scoreText;
    private int bestScore;

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
        //����� �������� ��Ʈ�� �ٲ�� ����
        FontManager.instance.ChangeAllFonts(InfoManager.instance.int_CurFontNum);

        //ī�� ����
        if (InfoManager.instance.int_level == 0)
        {
            GenerateCard1();
        }
        else
        {
            GenerateCard();
        }
        
        Time.timeScale = 1f;
        isCardGenerated = false;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<cameraShake>();
        Invoke("tryChanceTrue", 0.3f);

    }
    // Update is called once per frame
    void Update()
    {

        scoreText.text = score.ToString();
        //ī�� ��ġ
        if (isCardGenerated == false)
        {
            
            StartCoroutine(GenerateCardMoveToTarget(0.03f));
        }
        else
        {

            //������A�� �ڵ�
            time -= Time.deltaTime;
            timeText.text = time.ToString("N0");

            if (time <= 10.0f)
            {
                BgmManger.instance.ChangeBGMSpeed(1.3f);
                txtAnim.SetBool("light", true);
            }



            //���� ����
            if (time <= 0.0f && !isGameOver)
            {
                endTitleArrText[0].text = "�й�";
                BgmManger.instance.audioSource.Stop();
                EffectManager.instance.PlayEffectSound(EffectManager.instance.audio_Defeat);
                GameEnd();
            }
            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            //�¸�
            if (cardsLeft == 0 && !isGameOver)
            {
                BgmManger.instance.audioSource.Stop();
                BgmManger.instance.PlayBGMSound(BgmManger.instance.audio_GameClear[0]);
                endTitleArrText[0].text = "�¸�";
                GameEnd();
            }
        }

        if (firstCard != null)
        {
            checkTime += Time.deltaTime;
            if (checkTime >= 3)
            {
                firstCard.GetComponent<card>().CloseCard();
                firstCard = null;
                if (secondCard != null)
                {
                    secondCard.GetComponent<card>().CloseCard();
                    secondCard = null;
                }
                matchCount++;
            }
        }
        else
        {
            checkTime = 0;
        }

        
    }
    void tryChanceTrue()
    {
        tryChance = true;
    }

    public void IsMatched()
    {
        
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        Vector2 firstCardPos = new Vector2(firstCard.transform.position.x, firstCard.transform.position.y);
        Vector2 secondCardPos = new Vector2(secondCard.transform.position.x, secondCard.transform.position.y);

        if (firstCardImage == secondCardImage && firstCardPos != secondCardPos)
        {
            combo++;
            if (Maxcombo <= combo) Maxcombo = combo;
            firstCard.GetComponent<card>().DestroyCard();
            secondCard.GetComponent<card>().DestroyCard();

            if (combo == 1)
            {
                score += scorePower;
            }
            else
            {
                Invoke("ComboShow", 0.5f);
                score += scorePower * comboPower * combo;
            }


            SoundManager.instance.PlayEffectSound(SoundManager.instance.audio_Match);

            Invoke("stopDoubleClick", 0.3f);
            //�������� �ڵ�
            switch (firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name)
            {
                case "card0": InfoManager.instance.unlockInfo[0] = true; ShowNameText("��öȯ ����"); break;
                case "card1": InfoManager.instance.unlockInfo[1] = true; ShowNameText("��öȯ ����"); break;
                case "card2": InfoManager.instance.unlockInfo[2] = true; ShowNameText("������A"); break;
                case "card3": InfoManager.instance.unlockInfo[3] = true; ShowNameText("������A"); break;
                case "card4": InfoManager.instance.unlockInfo[4] = true; ShowNameText("������"); break;
                case "card5": InfoManager.instance.unlockInfo[5] = true; ShowNameText("������"); break;
                case "card6": InfoManager.instance.unlockInfo[6] = true; ShowNameText("�̻��"); break;
                case "card7": InfoManager.instance.unlockInfo[7] = true; ShowNameText("�̻��"); break;
                case "card8": InfoManager.instance.unlockInfo[8] = true; ShowNameText("������"); break;
                case "card9": InfoManager.instance.unlockInfo[9] = true; ShowNameText("������"); break;
                default: break;
            }
            

        }
        //Ʋ���� �� 
        else
        {
            Invoke("FailCard", 0.7f);
        }
        matchCount++;
    }

    void ComboShow()
    {
        ComboEffect.gameObject.SetActive(true);
        ComboEffect.text = "Combo" + (combo - 1);
        EffectManager.instance.PlayEffectSound(EffectManager.instance.audio_Combo);
        Invoke("ComboHide", 1f);
    }
    void ComboHide()
    {
        ComboEffect.gameObject.SetActive(false);
    }


    void FailCard()
    {
        EffectManager.instance.PlayEffectSound(EffectManager.instance.audio_Teemo);
        ShowNameText("����");
        if(firstCard != null)
        {
            firstCard.GetComponent<card>().CloseCard();
        }
        if (secondCard != null)
        {
            secondCard.GetComponent<card>().CloseCard();
        }
        Invoke("stopDoubleClick", 0.3f);
        //time -= 1f;
        score = score == 0 ? 0 : score - 1;
        
        combo = 0;
        failAnim.SetBool("fail", true);
        camera.VibrateForTime(VibrateForTime);
        Invoke("TxtAnimRelese", 1f);
    }

    void TxtAnimRelese()
    {
        failAnim.SetBool("fail", false);
    }

    void stopDoubleClick()
    {
        tryChance = true;
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
        
        time = 0;
        isGameOver = true;
        camera.endGame();
        SaveScore();
        endTitleArrText[1].text = PlayerPrefs.GetInt("BestScore").ToString(); ;
        endTitleArrText[2].text = score.ToString();
        endTitleArrText[3].text = matchCount.ToString();
        endTitleArrText[4].text = Maxcombo.ToString();
        endTitleArrText[5].text = (score / 10).ToString();
        InfoManager.instance.AddGold(score / 10);
        Time.timeScale = 0f;
        StartText.SetActive(false);
        endText.SetActive(true);
        score += (int)time;
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
            //���� ������Ʈ (������ ���)
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            //������� �ڵ� 
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.7f;
            newCard.transform.position = new Vector3(0f, 0f, 0f);

            //���� ������Ʈ�� �̵��ؾ� �� ��ǥ
            Vector3 target = new Vector3(x, y, 0);

            string rtanName = "card" + cards[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);

            //�迭�� �����ϱ� (������Ʈ, ������Ʈ�� �̵��� ��ǥ)
            cardList.Add(newCard, target);
        }
    }

    public void GenerateCard1()
    {
        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 5, 5, 6, 6, 7, 7, 9, 9 };
        cards = cards.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        cardsLeft = cards.Length;

        for (int i = 0; i < 16; i++)
        {
            //���� ������Ʈ (������ ���)
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            //������� �ڵ� 
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.7f;
            newCard.transform.position = new Vector3(0f, 0f, 0f);

            //���� ������Ʈ�� �̵��ؾ� �� ��ǥ
            Vector3 target = new Vector3(x, y, 0);

            string rtanName = "card" + cards[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);

            //�迭�� �����ϱ� (������Ʈ, ������Ʈ�� �̵��� ��ǥ)
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

    public void SaveScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        if (bestScore < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }


}


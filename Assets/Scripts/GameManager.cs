using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Text timeText;
    public GameObject endText;
    public GameObject card;
    float time=60.0f;
    float item;
    public GameObject firstCard;
    public GameObject secondCard;
    public AudioSource audioSource;
    public AudioClip match;
    int cardsLeft;
    public int score;
    public Text scoreText;
    public int combo;
    public Text[] scoreData = new Text[3];
    private int[] bestScore = new int[3];
    private bool isCardGenerated;	// 카드가 분배 되었는지 확인하기 위한 bool값
    public bool cardOpen;

    Dictionary<GameObject, Vector3> cardList = new Dictionary<GameObject, Vector3>();	// Generated 할 카드 오브젝트와 분배할 위치를 Dictionary에 저장


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

    // Start is called before the first frame update
    void Start()
    {
        cardOpen =true ;
        Time.timeScale = 1.0f;
        isCardGenerated = false;

        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 ,8 ,8 ,9 ,9};

        cards = cards.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        cardsLeft = cards.Length;

        float cardTerm = card.transform.localScale.x + 0.1f;

        for (int i = 0; i < 20; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;

            
            float x = (i / 5) * 1.4f - 2.1f;
            float y = (i % 5) * 1.4f - 4.0f;
            newCard.transform.position = new Vector3(0, 0, 0);

            Vector3 target = new Vector3(x, y, 0);
            string cardName = "card" + cards[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
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


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString("N0");
        scoreText.text = score.ToString();
        if (isCardGenerated == false)
        {
            StartCoroutine(GenerateCardMoveToTarget(0.03f));
        }
        if (time <= 10.0f)
        {
            timeText.color = Color.red;
        }
        //게임 오버
        if (time <= 0.0f)
        {
            GameEnd();
        }
    }

    public void IsMatched()
    {
        cardOpen = false;
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;


        if(firstCardImage == secondCardImage)
        {
            combo += 1;
            audioSource.PlayOneShot(match);
            firstCard.GetComponent<card>().DestroyCard();
            secondCard.GetComponent<card>().DestroyCard();
            if (combo == 1)
            {
                score += 10;
            }
            else if(combo == 2)
            {
                score += 20;
            }
            else
            {
                score += 30;
            }
            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            if (cardsLeft == 2)
            {
                Invoke("GameEnd",1.0f);
            }

        }
        else
        {
            score -= 1;
            if(score < 0)
            {
                score = 0;
            }
            combo = 0;
            firstCard.GetComponent<card>().CloseCard();
            secondCard.GetComponent<card>().CloseCard();
            firstCard.transform.Find("back").GetComponent<SpriteRenderer>().color = Color.grey;
            secondCard.transform.Find("back").GetComponent<SpriteRenderer>().color = Color.grey;
        }

        firstCard = null;
        secondCard = null;
    }

    void GameEnd()
    {
        //종료시키자!!
        Time.timeScale = 0f;
        endText.SetActive(true);
        score += (int)time;
        SaveScore();
        LoadScore();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);
        int tmpScore = 0;
        for(int i = 0; i < 3;i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            while (bestScore[i]<score)
            {
                tmpScore = bestScore[i];
                bestScore[i] = score;

                PlayerPrefs.SetInt(i + "BestScore", score);

                score = tmpScore;
            }
        }
        for(int i = 0;i< 3;i++) 
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
        }
        score = PlayerPrefs.GetInt("CurrentScore");
    }
    public void LoadScore()
    {
        for (int i = 0; i < 3; i++)
        {
            scoreData[i].text = PlayerPrefs.GetInt(i + "BestScore").ToString();
        }
    }

}

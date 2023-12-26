using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Text timeText;

    public Text NameText;
    public Text thisscoreTxt;
    public GameObject endText;
    public GameObject card;
    float time = 6.0f;

    float item;
    public GameObject firstCard;
    public GameObject secondCard;


    public AudioSource audioSource;
    public AudioClip match;

    public Animator txtAnim;
    public static gameManager I;



    public int matchCount;

    float checkTime = 0;

    bool isGameOver = false;
    //초반에 클릭 못하게 막기 및 2개 확인후에 진행되게끔 변경
    public bool tryChance = false;

    Dictionary<GameObject, Vector3> cardList = new Dictionary<GameObject, Vector3>();
    int cardsLeft;
    private bool isCardGenerated;


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

    void Start()
    {
        Time.timeScale = 1f;

        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
        cards = cards.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.7f;

            newCard.transform.position = new Vector3(x, y, 0);

            string cardName = "card" + cards[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");

        //게임 오버
        if(time >= 60f)
        {
            GameEnd();
        }
    }

    public void IsMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;


        if(firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().DestroyCard();
            secondCard.GetComponent<card>().DestroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            Debug.Log(GameObject.Find("Cards").transform.childCount);
            if (cardsLeft == 2)
            {
                //종료시키자!!
                Time.timeScale = 0f;
                endText.SetActive(true);
                Invoke("GameEnd", 1f);
            }
        }
        else
        {
            firstCard.GetComponent<card>().CloseCard();
            secondCard.GetComponent<card>().CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    void GameEnd()
    {
        //종료시키자!!
        Time.timeScale = 0f;
        endText.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}

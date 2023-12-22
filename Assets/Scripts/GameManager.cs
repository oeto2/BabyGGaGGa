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
    public GameObject endText;
    public GameObject card;
    float time=60.0f;
    float item;
    [HideInInspector] public GameObject firstCard;
    [HideInInspector] public GameObject secondCard;

    public AudioSource audioSource;
    public AudioClip match;
    int cardsLeft;

    private bool isCardGenerated;	// ī�尡 �й� �Ǿ����� Ȯ���ϱ� ���� bool��

    Dictionary<GameObject, Vector3> cardList = new Dictionary<GameObject, Vector3>();	// Generated �� ī�� ������Ʈ�� �й��� ��ġ�� Dictionary�� ����

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
        Time.timeScale = 1f;
        isCardGenerated = false;
        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 ,8,8,9,9};
        cards = cards.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            float x = (i / 5) * 1.4f - 2.1f;
            float y = (i % 5) * 1.4f - 4.0f;

            newCard.transform.position = new Vector3(x, y, 0);

            Vector3 target = new Vector3(x, y, 0);
            string cardName = "card" + cards[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
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
        timeText.text = time.ToString("N2");
        if (isCardGenerated == false)
        {
            StartCoroutine(GenerateCardMoveToTarget(0.03f));
        }

        if (time <= 10.0f)
        {
            timeText.color = Color.red;
        }
        //���� ����
        if (time <= 0.0f)
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
                //�����Ű��!!
                Time.timeScale = 0f;
                endText.SetActive(true);
                //Invoke("GameEnd", 1f);
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
        //�����Ű��!!
        Time.timeScale = 0f;
        endText.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}

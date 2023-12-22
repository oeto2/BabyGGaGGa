using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCard()
    {
        if (GameManager.instance.tryChance)
        {
            GameManager.instance.tryChance = false;
            anim.SetBool("isOpen", true);
            SoundManager.instance.PlayEffectSound(SoundManager.instance.audio_Flip);
            Invoke("Filp", 0.5f);

            if (GameManager.instance.firstCard == null)
            {
                Debug.Log("첫 번째 카드값 할당");
                GameManager.instance.firstCard = this.gameObject;
                Invoke("stopDoubleClick", 0.5f);
                Invoke("rollBack", 3f);
            }

            //Debug.Log($"firstcard : {GameManager.instance.firstCard}");
            //Debug.Log("현재 위치값: " + this.transform.position);
            //Debug.Log("첫번째 카드 포지션 값: " + GameManager.instance.firstCard.transform.position);
            else
            {
                Debug.Log("두 번째 카드값 할당");
                GameManager.instance.secondCard = gameObject;
                GameManager.instance.IsMatched();
                CancelInvoke("rollBack");
            }

            ////게임오브젝트 포지션값 != 게임매니저의 first카드 포지션 값
            //if (new Vector2(this.transform.position.x, this.transform.position.y)
            //    != new Vector2(GameManager.instance.firstCard.transform.position.x,
            //    GameManager.instance.firstCard.transform.position.y) && GameManager.instance.firstCard != null)
            //{
            //    Debug.Log("두 번째 카드값 할당");
            //    GameManager.instance.secondCard = gameObject;
            //    GameManager.instance.IsMatched();
            //    CancelInvoke("rollBack");
            //}


            if (this == GameManager.instance.firstCard)
            {
                Debug.Log("같은카드");
            }
        }
    }

    public void stopDoubleClick()
    {
        GameManager.instance.tryChance = true;
    }

    void Filp()
    {
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
    }

    void rollBack()
    {
        CloseCardInvoke();
        GameManager.instance.firstCard = null;
        GameManager.instance.matchCount++;

    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
        transform.Find("back").GetComponent<SpriteRenderer>().color = new Color(100.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 255.0f / 255.0f);
    }
}

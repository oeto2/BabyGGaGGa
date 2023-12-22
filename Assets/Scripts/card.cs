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
            anim.SetBool("isOpen", true);
            SoundManager.instance.PlayEffectSound(SoundManager.instance.audio_Flip);
            Invoke("Filp", 0.2f);

            //ù��° ī�尡 ����ٸ�
            if (GameManager.instance.firstCard == null)
            {
                GameManager.instance.firstCard = this.gameObject;
                Invoke("rollBack", 3f);
            }
            else
            {
                GameManager.instance.secondCard = gameObject;
                GameManager.instance.IsMatched();
            }
        }
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
        GameManager.instance.tryChance = true;
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
        GameManager.instance.tryChance = true;
    }
}

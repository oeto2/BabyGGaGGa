using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;
    public AudioSource audioSource;


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
            audioSource.PlayOneShot(flip);
            anim.SetBool("isOpen", true);
            transform.Find("front").gameObject.SetActive(true);
            transform.Find("back").gameObject.SetActive(false);

            //첫번째 카드가 비었다면
            if (GameManager.instance.firstCard == null)
            {
                GameManager.instance.firstCard = this.gameObject;
            }
            else
            {
                GameManager.instance.secondCard = gameObject;
                GameManager.instance.IsMatched();
            }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }
    
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }
    
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}

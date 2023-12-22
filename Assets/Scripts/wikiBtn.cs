using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wikiBtn : MonoBehaviour
{
    bool[] unlocks = {true, true, true, true, true, false, false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenwikiPage()
    {
        transform.parent.Find("wikiCanvas").gameObject.SetActive(true);
        Invoke("unlockBook", 1f);
    }

    void unlockBook()
    {
        for (int i = 0; i < 10; i++)
        {
            if (unlocks[i])
            {
                string book = "book" + i.ToString();
                transform.parent.Find("wikiCanvas").Find("wikibackground").Find(book).Find("Image").gameObject.SetActive(true);
                transform.parent.Find("wikiCanvas").Find("wikibackground").Find(book).Find("unlocked").gameObject.SetActive(false);
            }
        }
    }

    public void ShowwikiImage()
    {
        if (this.gameObject.GetComponent<Image>().sprite.name == "card0" 
            || this.gameObject.GetComponent<Image>().sprite.name == "card1")
        {
            wikiTextShow(0);
        }
        else if (this.gameObject.GetComponent<Image>().sprite.name == "card2"
            || this.gameObject.GetComponent<Image>().sprite.name == "card3")
        {
            wikiTextShow(1);
        }
        else if (this.gameObject.GetComponent<Image>().sprite.name == "card4"
            || this.gameObject.GetComponent<Image>().sprite.name == "card5")
        {
            wikiTextShow(2);
        }
        else if (this.gameObject.GetComponent<Image>().sprite.name == "card6"
            || this.gameObject.GetComponent<Image>().sprite.name == "card7")
        {
            wikiTextShow(3);
        }
        else if (this.gameObject.GetComponent<Image>().sprite.name == "card8"
            || this.gameObject.GetComponent<Image>().sprite.name == "card9")
        {
            wikiTextShow(4);
        }
    }

    void wikiTextShow(int memNum)
    {
        transform.parent.parent.Find("Descipt").gameObject.SetActive(true);
        Text[] allText = transform.parent.parent.Find("Descipt").Find("Canvas").GetComponentsInChildren<Text>();
        foreach(Text t in allText) 
        {
            t.gameObject.SetActive(false);
        }
        string txt = "Text" + memNum.ToString();
        string img = this.gameObject.GetComponent<Image>().sprite.name;
        transform.parent.parent.Find("Descipt").Find("Canvas").Find(txt).gameObject.SetActive(true);
        transform.parent.parent.Find("Descipt").Find("wikiImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(img);
    }

    public void ExitwikiDesciption()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void ExitwikiPage()
    {
        if(!transform.parent.Find("wikibackground").Find("Descipt").gameObject.activeSelf)
            transform.parent.gameObject.SetActive(false);
    }
}

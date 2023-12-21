using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wikiBtn : MonoBehaviour
{
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
    }

    public void ShowwikiImage()
    {
        if (this.gameObject.GetComponent<Image>().sprite.name == "card0")
        {
            transform.parent.Find("Descipt").gameObject.SetActive(true);

        }
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

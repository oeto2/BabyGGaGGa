using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ExitwikiPage()
    {
        transform.parent.gameObject.SetActive(false);
    }
}

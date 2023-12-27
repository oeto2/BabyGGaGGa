using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionBtn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOptPage()
    {
        if (!InfoManager.instance.isPageOpen)
        {
            InfoManager.instance.isPageOpen = true;
            transform.parent.Find("optionCanvas").gameObject.SetActive(true);
        }
    }

    public void ExitOptPage()
    {
        transform.parent.gameObject.SetActive(false);
        InfoManager.instance.isPageOpen = false;
    }
}

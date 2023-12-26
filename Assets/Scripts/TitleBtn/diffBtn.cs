using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diffBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void diffChange()
    {
        // 난이도 조절
        if (transform.Find("Normal").gameObject.activeSelf)
        {
            transform.Find("Normal").gameObject.SetActive(false);
            transform.Find("Hard").gameObject.SetActive(true);
            InfoManager.instance.int_level = 1;
        }
        else
        {
            transform.Find("Normal").gameObject.SetActive(true);
            transform.Find("Hard").gameObject.SetActive(false);
            InfoManager.instance.int_level = 0;
        }
    }
}

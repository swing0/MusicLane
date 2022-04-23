using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScence : MonoBehaviour
{
    public int scence_num;
    public bool isSelect;

    private void Awake()
    {
        Button mbutton = this.GetComponent<Button>();
        if (isSelect)
        {
            mbutton.Select();
        }
        mbutton.onClick.AddListener(clickButton);
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void clickButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scence_num);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{

    private void Awake()
    {
        Button mbutton = this.GetComponent<Button>();
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
        Application.Quit();
    }
}

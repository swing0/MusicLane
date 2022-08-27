using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToMessageBox : MonoBehaviour
{
    public string text;
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
        switch (text)
        {
            case "返回":
                MessageBox.instance.ShowMessageBox("确认" + text + "？",
                    new UnityEngine.Events.UnityAction(() => { UnityEngine.SceneManagement.SceneManager.LoadScene(4); }),
                    new UnityEngine.Events.UnityAction(() => { }));
                break;
            case "清空":
                MessageBox.instance.ShowMessageBox("确认" + text + "？",
                    new UnityEngine.Events.UnityAction(() => { GameObject.Find("EditScroller").GetComponent<EditScroller>().removeAllFires(); }),
                    new UnityEngine.Events.UnityAction(() => { }));
                break;
            case "保存":
                MessageBox.instance.ShowMessageBox("确认" + text + "？",
                    new UnityEngine.Events.UnityAction(() => { GameObject.Find("EditScroller").GetComponent<EditScroller>().getAllFires(); }),
                    new UnityEngine.Events.UnityAction(() => { }));
                break;
            default:
                break;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public static MessageBox instance;

    public RectTransform box;
    public Text content;
    public Button sureBtn;
    public Button cancelBtn;
    public float startY;
    public float moveTime;
    public bool isShow;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        box.gameObject.SetActive(false);
        startY = box.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMessageBox(string text,UnityAction sureAction, UnityAction cancelAction)
    {
        ShowMessageBoxSureCancel(moveTime, text, sureAction, cancelAction);
        isShow = true;

    }

    private void ShowMessageBoxSureCancel(float time, string text, UnityAction sureAction, UnityAction cancelAction)
    {
        sureBtn.gameObject.SetActive(true);
        cancelBtn.gameObject.SetActive(true);
        EnableButtons();

        sureBtn.onClick.RemoveAllListeners();
        if(sureAction != null)
        {
            sureBtn.onClick.AddListener(sureAction);
        }
        sureBtn.onClick.AddListener(DisableButtons);
        sureBtn.onClick.AddListener(HideMessageBox);

        cancelBtn.onClick.RemoveAllListeners();
        if (cancelAction != null)
        {
            cancelBtn.onClick.AddListener(cancelAction);
        }
        cancelBtn.onClick.AddListener(DisableButtons);
        cancelBtn.onClick.AddListener(HideMessageBox);
        content.text = text;

        StopAllCoroutines();
        StartCoroutine(ShowMessageBoxIE(time));
    }


    private IEnumerator ShowMessageBoxIE(float time,string text)
    {
        sureBtn.gameObject.SetActive(false);
        cancelBtn.gameObject.SetActive(false);
        content.text = text;

        yield return StartCoroutine(ShowMessageBoxIE(time));

        HideMessageBox();
    }

    private IEnumerator ShowMessageBoxIE(float time)
    {
        box.gameObject.SetActive(true);
        float count = 0;
        while(count < time)
        {
            count += Time.unscaledDeltaTime;
            box.localPosition = new Vector2(box.localPosition.x, Mathf.Lerp(startY, 0, count / time));
            yield return 0;
        }
        box.localPosition = new Vector2(box.localPosition.x, 0);
    }

    private void HideMessageBox()
    {
        StopAllCoroutines();
        StartCoroutine(HideMessageBoxIE(moveTime));
    }

    private IEnumerator HideMessageBoxIE(float time)
    {
        float count = 0;
        float lastY = box.localPosition.y;
        while (count < time)
        {
            count += Time.unscaledDeltaTime;
            box.localPosition = new Vector2(box.localPosition.x, Mathf.Lerp(lastY, startY, count / time));
            yield return 0;
        }
        box.localPosition = new Vector2(box.localPosition.x, startY);
        box.gameObject.SetActive(false);
        isShow = false;
    }

    private void DisableButtons()
    {
        sureBtn.interactable = false;
        cancelBtn.interactable = false;
    }

    private void EnableButtons()
    {
        sureBtn.interactable = true;
        cancelBtn.interactable = true;
    }
}

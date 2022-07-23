using CircularScrollView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getCells : MonoBehaviour
{

    public UICircularScrollView VerticalScroll;
    // Start is called before the first frame update
    void Start()
    {
        List<MapMessage> mapMessages = FileUtil.getAllCell();
        VerticalScroll.Init(NormalCallBack);
        VerticalScroll.ShowList(mapMessages.Count, mapMessages);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NormalCallBack(GameObject cell, MapMessage mapMessage)
    {
        cell.transform.Find("musicName").GetComponent<Text>().text = mapMessage.MusicName;
        cell.transform.Find("artist").GetComponent<Text>().text = mapMessage.Artist;
        cell.transform.Find("level").GetComponent<Text>().text = mapMessage.Level;
        cell.GetComponent<OneCell>().wifes = mapMessage.WifeNames;

        // …Ë÷√Õº∆¨
        cell.GetComponent<Image>().sprite = FileUtil.getSprite(mapMessage.ImageName,mapMessage.FilePathName);
        cell.GetComponent<OneCell>().filePathName = mapMessage.FilePathName;
        cell.GetComponent<OneCell>().imageName = mapMessage.ImageName;

        // …Ë÷√“Ù¿÷
        cell.GetComponent<OneCell>().musicPath = mapMessage.MusicPath;
        cell.GetComponent<OneCell>().filePathName = mapMessage.FilePathName;

       


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OneCell : MonoBehaviour, IPointerDownHandler
{

    public string imageName;
    public string filePathName;
    public string musicPath;
    public Dictionary<string, string> wifes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // 设置图片
        getImage mainInage = GameObject.Find("mainImage").GetComponent<getImage>();
        mainInage.imageName = imageName;
        mainInage.filePathName = filePathName;
        mainInage.updateImage();

        // 设置音乐
        getMusic music = GameObject.Find("music").GetComponent<getMusic>();
        music.musicPath = musicPath;
        music.filePath = filePathName;
        music.removeClip();
        music.updateMusic();
        music.playMusic();


        // 设置当前选中的文件信息
        CurrentMap button = GameObject.Find("CurrentMap").GetComponent<CurrentMap>();
        button.currentFilePathName = filePathName;


        // todo 设置舰娘
        string leftSDName = wifes["leftSD"];
        string midSDName = wifes["midSD"];
        string rightSDName = wifes["rightSD"];
        GameObject leftSD = GameObject.Find("leftSD");
        FileUtil.initSDObject(leftSDName, leftSD);
        GameObject midSD = GameObject.Find("midSD");
        FileUtil.initSDObject(midSDName, midSD);
        GameObject rightSD = GameObject.Find("rightSD");
        FileUtil.initSDObject(rightSDName, rightSD);


    }


}

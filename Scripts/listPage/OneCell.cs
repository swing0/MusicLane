using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OneCell : MonoBehaviour, IPointerDownHandler
{

    public string imageName;
    public string filePathName;
    public string musicPath;


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
    }


}

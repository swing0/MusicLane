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
        // ����ͼƬ
        getImage mainInage = GameObject.Find("mainImage").GetComponent<getImage>();
        mainInage.imageName = imageName;
        mainInage.filePathName = filePathName;
        mainInage.updateImage();

        // ��������
        getMusic music = GameObject.Find("music").GetComponent<getMusic>();
        music.musicPath = musicPath;
        music.filePath = filePathName;
        music.removeClip();
        music.updateMusic();
        music.playMusic();

        // ���õ�ǰѡ�е��ļ���Ϣ
        CurrentMap button = GameObject.Find("CurrentMap").GetComponent<CurrentMap>();
        button.currentFilePathName = filePathName;
    }


}

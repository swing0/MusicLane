using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ͼ(�ؿ�)��Ϣ

[System.Serializable]
public class MapMessage
{
    // �ļ���·��
    private string filePathName;
    // ͼƬ��
    private string imageName;
    // �ؿ����ڵ��ļ���
    private string pongJsonName;
    // �����ļ���ַ
    private string musicPath;
    // ������
    private string musicName;
    // ������(����)
    private string artist;
    // �Ѷ�
    private string level;
    // ��߷�
    private string maxScore;
    // �������
    private string maxLevel;
    // ������
    private Dictionary<string,string> wifeNames;

    public MapMessage() { }

    public MapMessage(string filePathName, string imageName, string pongJsonName, string musicPath, string musicName, string artist, string level, string maxScore, string maxLevel, Dictionary<string, string> wifeNames)
    {
        this.filePathName = filePathName;
        this.imageName = imageName;
        this.pongJsonName = pongJsonName;
        this.musicPath = musicPath;
        this.musicName = musicName;
        this.artist = artist;
        this.level = level;
        this.maxScore = maxScore;
        this.maxLevel = maxLevel;
        this.wifeNames = wifeNames;
    }

    public string FilePathName { get => filePathName; set => filePathName = value; }
    public string ImageName { get => imageName; set => imageName = value; }
    public string PongJsonName { get => pongJsonName; set => pongJsonName = value; }
    public string MusicName { get => musicName; set => musicName = value; }
    public string Artist { get => artist; set => artist = value; }
    public string Level { get => level; set => level = value; }
    public string MaxScore { get => maxScore; set => maxScore = value; }
    public string MaxLevel { get => maxLevel; set => maxLevel = value; }
    public Dictionary<string, string> WifeNames { get => wifeNames; set => wifeNames = value; }
    public string MusicPath { get => musicPath; set => musicPath = value; }
}

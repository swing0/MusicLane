using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 地图(关卡)信息

[System.Serializable]
public class MapMessage
{
    // 文件夹路径
    private string filePathName;
    // 图片名
    private string imageName;
    // 关卡内炮弹文件名
    private string pongJsonName;
    // 音乐文件地址
    private string musicPath;
    // 音乐名
    private string musicName;
    // 艺术家(作者)
    private string artist;
    // 难度
    private string level;
    // 最高分
    private string maxScore;
    // 最高评级
    private string maxLevel;
    // 舰娘名
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

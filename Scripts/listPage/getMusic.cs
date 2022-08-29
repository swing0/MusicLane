using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMusic : MonoBehaviour
{
    public string musicPath;
    public string filePath;

    private new AudioSource audio;
    private bool changePlay = false;

    private void Awake()
    {
        audio = this.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (changePlay)
        { 

            if (audio.isPlaying)
            {
                changePlay = false;
            }
            else
            {
                audio.Play();
            }
        }
    }

    public void updateMusic()
    {

        string fullName = FileUtil.getFileName(musicPath, filePath);
        if (fullName.EndsWith("wav"))
        {
            StartCoroutine(FileUtil.IELoadExternalAudioWebRequest(fullName, audio, AudioType.WAV));
        }
        else if (fullName.EndsWith("mp3"))
        {
            StartCoroutine(FileUtil.IELoadExternalAudioWebRequest(fullName, audio, AudioType.MPEG));
        }
        else
        {
            Debug.Log("音乐格式不支持");
        }

    }


    public void playMusic()
    {
        changePlay = true;
    }

    public void removeClip()
    {
        audio.clip = null;
    }
}

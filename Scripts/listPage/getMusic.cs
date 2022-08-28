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
        StartCoroutine(FileUtil.IELoadExternalAudioWebRequest(fullName, audio, AudioType.WAV));

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

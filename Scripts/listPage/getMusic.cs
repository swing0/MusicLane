using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMusic : MonoBehaviour
{
    public string musicName;

    private void Awake()
    {
        musicName = FileUtil.getFileName(musicName, "map/啼消のカタルシス02156");
        AudioSource audio = this.GetComponent<AudioSource>();
        StartCoroutine(FileUtil.IELoadExternalAudioWebRequest(musicName, audio, AudioType.WAV));

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public string filePathName;

    public GameObject leftSD, midSD, rightSD;

    //public int currentScore;
    //public int scorePerNote = 100;
    //public int scorePerGoodNote = 125;
    //public int scorePerPerfectNote = 150;

    //public int currentmultiplier;
    //public int multiplierTracker;
    //public int[] multiplierthresholds;

    //public Text scoreText;
    //public Text multiText;

    //public float totalNotes;
    //public float normalHits;
    //public float goodHits;
    //public float perfectHits;
    //public float missedHits;

    //public GameObject resultScreen;
    //public Text percentHitText, noramlsText, goodsText, perfectsText, missedText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {


        instance = this;
        filePathName = GameObject.Find("CurrentMap").GetComponent<CurrentMap>().currentFilePathName;

        MapMessage mapMessage = FileUtil.getMapMessageByFilePathName(filePathName);
        // …Ë÷√“Ù¿÷
        getMusic music = GameObject.Find("Audio").GetComponent<getMusic>();
        music.musicPath = mapMessage.MusicPath;
        music.filePath = filePathName;
        music.removeClip();
        music.updateMusic();

        // …Ë÷√±≥æ∞Õº
        getImage image = GameObject.Find("backImage").GetComponent<getImage>();
        image.filePathName = filePathName;
        image.imageName = mapMessage.ImageName;
        image.updateImage();

        // …Ë÷√Ω¢ƒÔ
        Dictionary<string, string> wifeNames = mapMessage.WifeNames;
        FileUtil.initSDObject(wifeNames["leftSD"], leftSD);
        FileUtil.initSDObject(wifeNames["midSD"], midSD);
        FileUtil.initSDObject(wifeNames["rightSD"], rightSD);
        //scoreText.text = "Score: 0";
        //currentmultiplier = 1;

        //totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                Invoke("PlayMusic", 1.9f);
            }
        }
        else
        {
            //if (!theMusic.isPlaying && !resultScreen.activeInHierarchy)
            //{
            //    resultScreen.SetActive(true);

            //    noramlsText.text = "" + normalHits;
            //    goodsText.text = goodHits.ToString();
            //    perfectsText.text = perfectHits.ToString();
            //    missedText.text = "" + missedHits;

            //    float totalHit = normalHits + goodHits + perfectHits;
            //    float percentHit = (totalHit / totalNotes) * 100f;

            //    percentHitText.text = percentHit.ToString("F2") + "%";

            //    string rankVal = "F";

            //    if (percentHit > 40)
            //    {
            //        rankVal = "D";
            //        if(percentHit > 55)
            //        {
            //            rankVal = "C";
            //            if (percentHit > 70)
            //            {
            //                rankVal = "B";
            //                if (percentHit > 85)
            //                {
            //                    rankVal = "A";
            //                    if (percentHit > 95)
            //                    {
            //                        rankVal = "S";
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    rankText.text = rankVal;
            //    finalScoreText.text = currentScore.ToString();
            //}
        }
    }

    public void PlayMusic()
    {
        theMusic.Play();
    }

    //public void NoteHit()
    //{
    //    Debug.Log("Hit On Time");

    //    if(currentmultiplier - 1 < multiplierthresholds.Length)
    //    {
    //        multiplierTracker++;

    //        if (multiplierthresholds[currentmultiplier - 1] <= multiplierTracker)
    //        {
    //            multiplierTracker = 0;
    //            currentmultiplier++;
    //        }
    //    }
    //    multiText.text = "Multiplier: x" + currentmultiplier;
    //    scoreText.text = "Score: " + currentScore;
    //}

    //public void NormalHit()
    //{
    //    currentScore += scorePerNote * currentmultiplier;
    //    NoteHit();
    //    normalHits++;
    //}

    //public void GoodHit()
    //{
    //    currentScore += scorePerGoodNote * currentmultiplier;
    //    NoteHit();
    //    goodHits++;
    //}
    //public void PerfectHit()
    //{
    //    currentScore += scorePerPerfectNote * currentmultiplier;
    //    NoteHit();
    //    perfectHits++;
    //}

    //public void NoteMissed()
    //{
    //    Debug.Log("Missed Note");

    //    currentmultiplier = 1;
    //    multiplierTracker = 0;
    //    multiText.text = "Multiplier: x" + currentmultiplier;

    //    missedHits++;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getImage : MonoBehaviour
{
    public string imageName;
    public string filePathName;
    private void Awake()
    {

    }

    public void updateImage()
    {
        this.GetComponent<Image>().sprite = FileUtil.getSprite(imageName, filePathName);
    }


}

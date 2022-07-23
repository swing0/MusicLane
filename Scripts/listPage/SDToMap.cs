using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SDToMap : MonoBehaviour
{

    private void Awake()
    {
        Button mbutton = this.GetComponent<Button>();
        mbutton.onClick.AddListener(clickButton);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickButton()
    {

        // 获取选中的关卡
        string filePathName = GameObject.Find("CurrentMap").GetComponent<CurrentMap>().currentFilePathName;
        MapMessage mapMessage = FileUtil.getMapMessageByFilePathName(filePathName);

        
        string leftSDName = GameObject.Find("leftSD").GetComponent<SkeletonAnimation>().SkeletonDataAsset == null?"null_": GameObject.Find("leftSD").GetComponent<SkeletonAnimation>().SkeletonDataAsset.name;
        leftSDName = leftSDName.Substring(0, leftSDName.IndexOf("_"));
        string midSDName = GameObject.Find("midSD").GetComponent<SkeletonAnimation>().SkeletonDataAsset == null ? "null_" : GameObject.Find("midSD").GetComponent<SkeletonAnimation>().SkeletonDataAsset.name;
        midSDName = midSDName.Substring(0, midSDName.IndexOf("_"));
        string rightSDName = GameObject.Find("rightSD").GetComponent<SkeletonAnimation>().SkeletonDataAsset == null ? "null_" : GameObject.Find("rightSD").GetComponent<SkeletonAnimation>().SkeletonDataAsset.name;
        rightSDName = rightSDName.Substring(0, rightSDName.IndexOf("_"));

        Dictionary<string, string> wifes = new Dictionary<string, string>();
        wifes.Add("leftSD", leftSDName);
        wifes.Add("midSD", midSDName);
        wifes.Add("rightSD", rightSDName);
        mapMessage.WifeNames = wifes;


        FileUtil.saveFireMapMessage(mapMessage);
    }
}

using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BondChara : MonoBehaviour, IPointerDownHandler
{

    public GameObject SelectLabel;
    public GameObject SelectChara;

    SkeletonAnimation skeletonAnimation;
    Spine.AnimationState animationState;

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
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        animationState = skeletonAnimation.AnimationState;
        if (skeletonAnimation.skeletonDataAsset != null)
        {
            animationState.SetAnimation(0, "touch", false);

            string fullName =  skeletonAnimation.skeletonDataAsset.name;
            string englishName = fullName.Split("_")[0];
            string chineseName = DictionaryUtil.getKeyByValue(englishName);

            SelectLabel.GetComponent<Text>().text = chineseName;

        }
        else
        {
            SelectLabel.GetComponent<Text>().text = "无";
        }

        // 将下拉选择框绑定到当前点击的舰娘
        SelectChara.GetComponent<SelectChara>().SDObject = this.gameObject;
    }
}

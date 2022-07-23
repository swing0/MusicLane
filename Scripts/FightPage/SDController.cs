using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using System;

public class SDController : MonoBehaviour
{
    public List<KeyCode> keyCodes;

    private static float LONGPRESS = 0.25f; //按钮超过LONGPRESS判定为长按
    private float pressTime = 0f;
    SkeletonAnimation skeletonAnimation;
    Spine.AnimationState animationState;
    Skeleton skeleton;

    private void Awake()
    {
        
    }

    private void OnSpineAnimationComplete(TrackEntry trackEntry)
    {
        animationState.SetAnimation(0, "move", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        initSkeletion();
    }

    // Update is called once per frame
    void Update()
    {
        if (skeletonAnimation.skeletonDataAsset != null)
        {
            if (getKeysDown(keyCodes))
            {
                pressTime = 0f;
                skeletonAnimation.state.SetAnimation(0, "attack", false);
            }
            if (getKeys(keyCodes))
            {
                pressTime += Time.deltaTime;
                if (pressTime > LONGPRESS)
                {
                    if (animationState.ToString() == "attack_left")
                    {

                    }
                    else
                    {
                        skeletonAnimation.state.SetAnimation(0, "attack_left", false);
                    }
                }
            }
        }
    }

    public void initSkeletion()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        if (skeletonAnimation.skeletonDataAsset != null)
        {
            skeleton = skeletonAnimation.Skeleton;
            animationState = skeletonAnimation.AnimationState;
            animationState.SetAnimation(0, "move", false);
            animationState.TimeScale = 1.5f;


            animationState.Complete += OnSpineAnimationComplete;
        }
    }

    private bool getKeysDown(List<KeyCode> codes)
    {
        bool flag = false;
        codes.ForEach(delegate (KeyCode code)
        {
            if (Input.GetKeyDown(code))
            {
                flag = true;
            }
        }
        );
        return flag;
    }

    private bool getKeys(List<KeyCode> codes)
    {
        bool flag = false;
        codes.ForEach(delegate (KeyCode code)
        {
            if (Input.GetKey(code))
            {
                flag = true;
            }
        }
        );
        return flag;
    }

}

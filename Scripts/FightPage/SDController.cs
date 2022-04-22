using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SDController : MonoBehaviour
{
    public List<KeyCode> keyCodes;

    private static float LONGPRESS = 0.25f; //按钮超过LONGPRESS判定为长按
    private float pressTime = 0f;
    private SkeletonAnimation skeletonAnimation;

    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = this.GetComponent<SkeletonAnimation>();
        if (skeletonAnimation.skeletonDataAsset != null) skeletonAnimation.state.SetAnimation(0, "move", true);
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
                    skeletonAnimation.state.SetAnimation(0, "attack_left", false);
                }
            }
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

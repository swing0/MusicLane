using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public KeyCode keyToPress;
    public RuntimeAnimatorController[] runtimeAnimatorControllers;

    // private SpriteRenderer theSR;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        // theSR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            animator.runtimeAnimatorController = runtimeAnimatorControllers[0];
            animator.Play("Hit-1 Animation", 0, 0f);
        }
    }
}

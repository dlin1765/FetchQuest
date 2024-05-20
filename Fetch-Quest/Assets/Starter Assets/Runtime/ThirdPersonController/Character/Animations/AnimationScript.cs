using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mAnimator.SetTrigger("Jump");
                Debug.Log("SpaceKeyPress");
            }    
            if (Input.GetKeyDown(KeyCode.F))
            {
                mAnimator.SetTrigger("StartGame");
                Debug.Log("FKeyPress");
            }
        
        }
    }
}

using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorScript : MonoBehaviour
{
    private Animator mAnimator;
    public Rigidbody rb;
    public bool robotIsOnGround;


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       
    }
    private void Awake()
    {
        //GameStateManager.gameStateChanged += GameStateManagerGameStateChanged;
       
    }

    // Update is called once per frame
    void Update()
    {

        
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) && robotIsOnGround)
            {
                robotIsOnGround = false;
                mAnimator.SetTrigger("Jump");
                Debug.Log("SpaceKeyPress");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                mAnimator.SetTrigger("StartGame");
                Debug.Log("FKeyPress");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                mAnimator.SetTrigger("Slide");
                Debug.Log("SKeyPress");
            }


        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            robotIsOnGround = true;
        }
    }

}
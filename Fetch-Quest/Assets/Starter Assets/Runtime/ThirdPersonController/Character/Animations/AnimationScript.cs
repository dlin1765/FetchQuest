using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator mAnimator;
    public float speed = 10f;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontal, 0, vertical);


        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mAnimator.SetTrigger("Jump");
                rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
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


}
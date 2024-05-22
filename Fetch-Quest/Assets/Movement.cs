using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public bool robotIsOnGround = true;
    private float horizontal;
    private Animator mAnimator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
    }

    private void Awake()
    {
        GameStateManager.gameStateChanged += GameStateManagerGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.gameStateChanged -= GameStateManagerGameStateChanged;
    }

    private void GameStateManagerGameStateChanged(GameStateManager.GameState state)
    {
        if (state == GameStateManager.GameState.Intro)
        {
            //dont move
            Debug.Log("Intro happening");
        }
        else if (state == GameStateManager.GameState.Playing)
        {
            mAnimator.SetTrigger("StartGame");

        }
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, 0);
        if (Input.GetButton("Jump") && robotIsOnGround)
        {
            mAnimator.SetTrigger("Jump");
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            robotIsOnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            mAnimator.SetTrigger("Slide");
            Debug.Log("SKeyPress");
        }
    }




    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("entered floor");
            robotIsOnGround = true;
        }
    }
}

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
        }
        else if (state == GameStateManager.GameState.Playing)
        {
            mAnimator.SetTrigger("StartGame");
            StartCoroutine(PlayerControls());

        }
        else if(state == GameStateManager.GameState.Win)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
       
    }

    private IEnumerator PlayerControls()
    {
        while(this.gameObject != null)
        {
            horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(horizontal, 0, 0);
            if (Input.GetButton("Jump") && robotIsOnGround)
            {
                mAnimator.SetTrigger("Jump");
                rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
                robotIsOnGround = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                mAnimator.SetTrigger("Slide");
                Debug.Log("SKeyPress");
            }
            yield return null;
        }
    }



    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            robotIsOnGround = true;
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.Failure);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public bool robotIsOnGround = true;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        
        transform.Translate(horizontal, 0, 0);

        
        if (Input.GetButton("Jump") && robotIsOnGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            robotIsOnGround = false;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            robotIsOnGround = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public bool robotIsOnGround = true;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.TransformDirection(horizontal, 0, vertical);

        if (Input.GetButton("Jump") && robotIsOnGround)
        rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        robotIsOnGround = false;
    }
}
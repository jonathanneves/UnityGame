using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{

    Rigidbody myRigidbody;

    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float jumpPower = 0f;
    float hInput;
    float vInput;
    bool jumpInput;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * moveSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        Move();

        if (jumpInput)
        {
            Jump();
            jumpInput = false;
        }

    }

    void Move()
    {
        myRigidbody.AddForce(hInput * Time.fixedDeltaTime, 0f, vInput * Time.fixedDeltaTime);
    }

    void Jump()
    {
        myRigidbody.AddForce(Vector3.up * jumpPower * Time.fixedDeltaTime, ForceMode.Impulse);
    }


}

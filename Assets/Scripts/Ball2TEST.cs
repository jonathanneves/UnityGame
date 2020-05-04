using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2TEST : MonoBehaviour
{

    public float Speed;
    Rigidbody myRigidbody;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void FixedUpdate()
    {
        PlayerMovement();
    }

    // Update is called once per frame
    void PlayerMovement()
    {

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 playerMoviment = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMoviment, Space.Self);

        //myRigidbody.MovePosition(Speed * 1f * Time.deltaTime);
        // I tried my best to explain this in my answer
        //cam.transform.localRotation = Quaternion.Euler(-mouseLook.y, mouseLook.x, 0f);
        //myRigidbody.MoveRotation(Quaternion.Euler(cam.transform.localRotation.eulerAngles));


        //myRigidbody.AddForce(hor * Speed * Time.fixedDeltaTime, 0f, ver * Speed * Time.fixedDeltaTime);
        //myRigidbody.AddForce(hor * Speed * Time.fixedDeltaTime, 0f, ver * Speed * Time.fixedDeltaTime);
        //myRigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        //Vector3 newPosition = myRigidbody.position + transform.TransformDirection(localPositionOffset);
        //myRigidbody.MovePosition(newPosition);
    }
}

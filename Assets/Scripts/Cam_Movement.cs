using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Movement : MonoBehaviour
{
    public float turnSpeed = 4.0f;  
    public Transform player;
    private Vector3 offset;
  
    void Start () {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {


        if(player != null)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position);
        }

    }
}

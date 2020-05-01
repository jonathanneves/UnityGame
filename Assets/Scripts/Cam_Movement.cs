using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Movement : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float followSpeed = 0f;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

        offset = target.position - transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, target.position - offset, Time.deltaTime * followSpeed);

    }
}

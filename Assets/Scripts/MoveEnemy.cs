using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform[] targets;
    private int[] teste;
    private int currentTarget;
    public float speed;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentTarget = Random.Range(0, 1);
        RotateModel();
    }

    void FixedUpdate()
    {

        if (Vector3.Distance(this.transform.position, targets[currentTarget].position) > 0.25f){
            Vector3 newPos = (targets[currentTarget].position - transform.position).normalized * speed;
            rb.velocity = newPos;
        } else {
            currentTarget -= 1;
            currentTarget *= -1;          
            RotateModel();
        }
    }

    void RotateModel(){
        if (currentTarget == 0)
            this.transform.Rotate(0,180,0);
        else
            this.transform.Rotate(0, -180, 0);
    }
}

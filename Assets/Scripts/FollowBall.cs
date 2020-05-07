using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start(){
          offset = this.transform.localPosition - player.transform.localPosition;
    }

    void FixedUpdate()
    {
        this.transform.position = player.transform.localPosition + offset;
    }
}

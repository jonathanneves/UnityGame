using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
        Invoke("DestroyMe", 1.5f);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.position);
    }

    void DestroyMe(){
        Destroy(this.gameObject);
    }
}

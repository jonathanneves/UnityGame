using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_Item : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * speed * Time.deltaTime);
    }

}

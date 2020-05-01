using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DeleteObject", 1f);
    }

    void DeleteObject()
    {
        DestroyObject(this.gameObject);
    }
}

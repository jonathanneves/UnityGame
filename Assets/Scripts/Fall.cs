using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter(Collider o){
        if (o.CompareTag("Player")){
            FindObjectOfType<Health_Controller>().tomouDano();
            o.GetComponent<Ball_Movement>().resetPos();
        }
    }
}

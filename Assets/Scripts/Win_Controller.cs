using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Controller : MonoBehaviour
{
    public GameObject particleSucess;

    private void OnTriggerEnter(Collider o){

        Debug.Log("Travo ?");

        if (o.gameObject.CompareTag("Player")){

            if(FindObjectOfType<Score>().podeganhar){
                Instantiate(particleSucess, o.gameObject.transform.position, Quaternion.identity);
                Debug.Log("VENCEU");

            } else {
                Debug.Log("Colete Todos");
                //AUDIO ERROU
            }
        }
    }
}

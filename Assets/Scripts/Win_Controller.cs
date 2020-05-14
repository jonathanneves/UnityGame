using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Controller : MonoBehaviour
{
    public GameObject particleSucess;
    public GameObject panel;
    public Text tipText;

    private void OnTriggerEnter(Collider o){

        if (o.gameObject.CompareTag("Player")){

            if(FindObjectOfType<Score>().podeganhar){
                Instantiate(particleSucess, o.gameObject.transform.position, Quaternion.identity);
                Destroy(o);
                StartCoroutine("vitoria");
            } else {
                StartCoroutine("showTip");
            }
        }
    }

    IEnumerator vitoria() {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    IEnumerator showTip(){
        tipText.text = "Colete todas as "+ FindObjectOfType<Score>().maxScore + " frutas antes";
        yield return new WaitForSeconds(3f);
        tipText.text = "";
    }
}

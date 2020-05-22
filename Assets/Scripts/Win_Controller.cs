using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Controller : MonoBehaviour
{
    public GameObject particleSucess;
    public GameObject panel;
    public Text tipTxt;
    public Text timeTxt;

    private void OnTriggerEnter(Collider o){

        if (o.gameObject.CompareTag("Player")){

            if(FindObjectOfType<Score>().podeganhar){
                Instantiate(particleSucess, o.gameObject.transform.position, Quaternion.identity);
                Destroy(o.gameObject);
                StartCoroutine("vitoria");
            } else {
                StartCoroutine("showTip");
            }
        }
    }

    IEnumerator vitoria() {
        AudioManager.instance.PlayVictory();
        yield return new WaitForSeconds(2f);
        timeTxt.text = FindObjectOfType<Timer>().atualizarTempo();
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    IEnumerator showTip(){
        tipTxt.text = "Colete todas as "+ FindObjectOfType<Score>().maxScore + " frutas antes!";
        yield return new WaitForSeconds(3f);
        tipTxt.text = "";
    }
}

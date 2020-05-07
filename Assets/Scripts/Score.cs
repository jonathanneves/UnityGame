using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private TextMesh scoreText;
    private Text scoreOnPause;
    private int maxScore;
    private int currentScore = 0;
    [HideInInspector] public bool podeganhar = false;

    void Awake()
    {
        scoreText = GameObject.Find("Pontos").GetComponent<TextMesh>();
        scoreOnPause = GameObject.Find("Score").GetComponent<Text>();
        maxScore = GameObject.Find("Good Food").GetComponent<Transform>().childCount;
        scoreText.text = currentScore+"/"+maxScore;
    }

    public void atualizarScore(){
        currentScore++;
        scoreText.text = currentScore + "/" + maxScore;
        scoreOnPause.text = currentScore + "/" + maxScore;
        StartCoroutine("animacaoUI");
        if (currentScore == maxScore){
            podeganhar = true;
            Debug.Log("Pode Ganhar");
        }else {
            Debug.Log("Não pode ganhar ainda");
        }
    }

    IEnumerator animacaoUI() {
        scoreOnPause.enabled = true;
        yield return new WaitForSeconds(2.25f);
        scoreOnPause.enabled = false;
    }
}

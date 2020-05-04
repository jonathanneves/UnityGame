using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private TextMesh scoreText;
    private int maxScore;
    private int currentScore = 0;
    [HideInInspector] public bool podeganhar = false;

    void Start()
    {
        scoreText = GameObject.Find("Pontos").GetComponent<TextMesh>();
        maxScore = GameObject.Find("Good Food").GetComponent<Transform>().childCount;
        scoreText.text = currentScore+"/"+maxScore;
    }

    public void atualizarScore(){
        currentScore++;
        scoreText.text = currentScore + "/" + maxScore;
        if(currentScore == maxScore){
            podeganhar = true;
            Debug.Log("Pode Ganhar");
        }else {
            Debug.Log("Não pode ganhar ainda");
        }
    }
}

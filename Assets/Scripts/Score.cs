using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text tipText;
    public string tipLevel;
    private TextMesh scoreText;
    private Text scoreOnPause;
    public int maxScore;
    private int currentScore = 0;
    [HideInInspector] public bool podeganhar = false;

    void Awake()
    {
        maxScore = GameObject.Find("Good Food").GetComponent<Transform>().childCount;
        scoreText = GameObject.Find("Pontos").GetComponent<TextMesh>();
        scoreOnPause = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = currentScore+"/"+maxScore;
    }

    public void atualizarScore(){
        currentScore++;
        scoreText.text = currentScore + "/" + maxScore;
        scoreOnPause.text = currentScore + "/" + maxScore;
        StartCoroutine("animacaoUI");
        if (currentScore == maxScore) {
            podeganhar = true;
            StartCoroutine("showTip");
        }
    }

    IEnumerator showTip() {
        tipText.text = tipLevel;
        yield return new WaitForSeconds(3f);
        tipText.text = "";
    }

    IEnumerator animacaoUI() {
        scoreOnPause.enabled = true;
        yield return new WaitForSeconds(2.25f);
        scoreOnPause.enabled = false;
    }
}

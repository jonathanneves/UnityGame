using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float timer = 0;
    string varTime;

    void Update() {

        timer += Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        varTime = minutes + ":" + seconds;
    }

    public string atualizarTempo(){
       return "Seu tempo: "+ varTime;
    }
}

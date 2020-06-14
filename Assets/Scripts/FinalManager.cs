using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour
{
    public Transform pivot;
    public Text tempos;

    void Start(){
        string varTime = "Tempos \n\n";
        varTime += PlayerPrefs.GetString("Basketball Scene") + "\n";
        varTime += PlayerPrefs.GetString("Volley Scene") + "\n";
        varTime += PlayerPrefs.GetString("Football Scene");
        tempos.text = varTime;
        AudioManager.instance.PlayVictory();
        Cursor.visible = true;
    }

    public void voltar(){
        SceneManager.LoadScene("Menu");
    }

    public void proximo() {
        pivot.localPosition = new Vector3(-2000f, 0f, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Transform pivot;
    public Sprite[] currentAudio;
    private Image audioUI;
    bool estaMutado = false;

    void Start(){
        audioUI = GameObject.Find("Mute").GetComponent<Image>();
    }

    public void startGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void sair(){
        Application.Quit();
    }

    public void creditos(){
        pivot.localPosition = new Vector3(2500f,0f,0f);
    }

    public void comoJogar() {
        pivot.localPosition = new Vector3(-2500f, 0f, 0f);
    }

    public void voltar(){
        pivot.localPosition = new Vector3(0, 0f, 0f);
    }

    public void mute() {
        estaMutado = !estaMutado;
        if (!estaMutado) {
            audioUI.sprite = currentAudio[0];
        }
        else {
            audioUI.sprite = currentAudio[1];
        }
    }
}

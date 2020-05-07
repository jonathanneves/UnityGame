using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool estaPausado = false;
    bool estaMutado = false;
    public GameObject pause;
    public Image audioUI;
    private Text scoreText;
    private Image healthUI;
    public Sprite[] currentAudio;

    void Awake(){
        healthUI = GameObject.Find("HP").GetComponent<Image>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (!estaPausado) {
                pausar();
            } else {
                despausar();
            }
        }
    }

    public void resume(){
        estaPausado = false;
        pause.SetActive(false);
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

    public void exit(){
        SceneManager.LoadScene("Menu");
    }

    void pausar(){
        estaPausado = true;
        pause.SetActive(true);
        scoreText.enabled = true;
        healthUI.enabled = true;
    }

    void despausar(){
        estaPausado = false;
        pause.SetActive(false);
        scoreText.enabled = false;
        healthUI.enabled = false;
    }

}

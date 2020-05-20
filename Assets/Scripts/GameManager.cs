using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool estaPausado = false;
    bool estaMutado = false;
    private AudioSource bgSound;

    //Paineis
    private GameObject pause;
    private GameObject winner;
    private GameObject gameOver;

    //UI 
    public Image audioUI;
    private Text scoreText;
    private Image healthUI;
    public Sprite[] currentAudio;

    void Awake(){
        pause = GameObject.Find("Pause");
        pause.SetActive(false);
        GameObject.Find("Winner").SetActive(false);
        GameObject.Find("GameOver").SetActive(false);
        healthUI = GameObject.Find("HP").GetComponent<Image>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        if(AudioManager.instance != null)
            bgSound = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    void Start(){
        PlayerPrefs.SetInt("Fase", SceneManager.GetActiveScene().buildIndex);
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
            bgSound.Play();
        }
        else {
            audioUI.sprite = currentAudio[1];
            bgSound.Stop();
        }
    }

    public void exit(){
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Fase", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }

    public void restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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

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
    public GameObject pause;
    public GameObject winner;
    public GameObject gameOver;
    public GameObject loading;

    //UI 
    public Image audioUI;
    private Text scoreText;
    private Image healthUI;
    public Sprite[] currentAudio;

    void Awake(){
        healthUI = GameObject.Find("HP").GetComponent<Image>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        if(AudioManager.instance != null)
            bgSound = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameOver.activeSelf && !winner.activeSelf){
            if (!estaPausado) {
                pausar();
            } else {
                despausar();
            }
        }
    }

    public void resume(){
        Time.timeScale = 1f;
        estaPausado = false;
        pause.SetActive(false);
        scoreText.enabled = false;
        healthUI.enabled = false;
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
        SceneManager.LoadScene("Menu");
    }

    public void restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel(){
        StartCoroutine("LoadingScene");
    }

    IEnumerator LoadingScene(){
        loading.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void pausar(){
        Time.timeScale = 0f;
        estaPausado = true;
        pause.SetActive(true);
        scoreText.enabled = true;
        healthUI.enabled = true;
    }

    void despausar(){
        Time.timeScale = 1f;
        estaPausado = false;
        pause.SetActive(false);
        scoreText.enabled = false;
        healthUI.enabled = false;
    }

}

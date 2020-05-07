using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool estaPausado = false;
    public GameObject pause;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (!estaPausado) {
                estaPausado = true;
                pause.SetActive(true);
            } else {
                estaPausado = false;
                pause.SetActive(false);
            }
        }
    }

    public void resume(){
        estaPausado = false;
        pause.SetActive(false);
    }

    public void exit(){
        SceneManager.LoadScene("Menu");
    }
}

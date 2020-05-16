using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    public void voltar(){
        PlayerPrefs.SetInt("Fase", 1);
        SceneManager.LoadScene("Menu");
    }
}

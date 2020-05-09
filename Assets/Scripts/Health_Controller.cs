using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Controller : MonoBehaviour
{
    private int health = 3;
    private Image imageUI;
    public Sprite[] healthBar;

    void Awake(){
        imageUI = GameObject.Find("HP").GetComponent<Image>();
    }

    public void tomouDano(){
        imageUI.sprite = healthBar[health];
        StartCoroutine("animacaoUI");
    }
    
    IEnumerator animacaoUI(){
        imageUI.enabled = true;
        imageUI.sprite = healthBar[health];
        yield return new WaitForSeconds(0.75f);
        health--;
        imageUI.sprite = healthBar[health];
        yield return new WaitForSeconds(2.5f);
        imageUI.enabled = false;
    }


    void Update()
    {
        if(health == 0 && imageUI.IsActive()){
            gameOver();
        }
    }

    void gameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

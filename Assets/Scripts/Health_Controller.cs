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
    public GameObject panel;
    private GameObject player;

    void Awake(){
        imageUI = GameObject.Find("HP").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void tomouDano(){
        imageUI.sprite = healthBar[health];
        StartCoroutine("animacaoUI");
    }
    
    IEnumerator animacaoUI(){
        imageUI.enabled = true;
        imageUI.sprite = healthBar[health];
        yield return new WaitForSeconds(0.3f);
        health--;
        imageUI.sprite = healthBar[health];
        if (health == 0) {
            yield return new WaitForSeconds(0.2f);
            gameOver();
        } else {
            yield return new WaitForSeconds(2f);
            imageUI.enabled = false;
        }
    }

    void gameOver(){
        AudioManager.instance.PlayGameOver();
        imageUI.enabled = false;
        GameObject.Find("Score").GetComponent<Text>().enabled = false;
        Destroy(player, 0.2f);
        panel.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public int getHealth(){
        return health;
    }

}

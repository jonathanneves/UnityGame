using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Movement : MonoBehaviour
{


    Rigidbody myRigidbody;
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float jumpPower = 0f;
    float hInput;
    float vInput;
    Vector3 initPos;

    [Header("UI")]
    public GameObject particulaGood;
    public GameObject particulaBad;
    public GameObject popUpScore;
    public GameObject popUpHP;

    // Start is called before the first frame update
    void Start()
    {
        initPos = this.transform.position;
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * moveSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        if(Input.GetKeyDown(KeyCode.Space)) {
            if (Physics.Raycast(transform.position, Vector3.down, 0.7f))
                Jump();      
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        myRigidbody.AddForce(hInput * Time.fixedDeltaTime, 0f, vInput * Time.fixedDeltaTime);
    }

    void Jump()
    {
        myRigidbody.AddForce(0, jumpPower, 0);
        AudioManager.instance.BallJump();
    }


    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.CompareTag("Good Food")){   
            AudioManager.instance.CollectFruit();
            ativarParticula(o.gameObject, particulaGood, popUpScore);
            FindObjectOfType<Score>().atualizarScore();
        }
        else if (o.gameObject.CompareTag("Bad Food")) {
            AudioManager.instance.CollectJunk();
            ativarParticula(o.gameObject, particulaBad, popUpHP);
            FindObjectOfType<Health_Controller>().tomouDano();
        }
    }

    void ativarParticula(GameObject go, GameObject particule, GameObject popUP){
        GameObject particle = Instantiate(particule, go.transform.position, Quaternion.identity);
        GameObject popUp = Instantiate(popUpScore, go.transform.position, Quaternion.identity);
        Destroy(go);
        Destroy(particle, 0.5f);
        Destroy(popUp, 1.5f);
    }

    public void resetPos(){
        this.transform.position = initPos;
    }

}

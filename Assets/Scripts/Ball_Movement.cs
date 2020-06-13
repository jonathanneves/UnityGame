using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Movement : MonoBehaviour
{

    public Transform cameraTransform;
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
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

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
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 direction = forward * vInput + right * hInput;
        myRigidbody.AddForce(direction * moveSpeed);
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

    void ativarParticula(GameObject go, GameObject particle, GameObject popUp){
        GameObject goParticle = Instantiate(particle, go.transform.position, Quaternion.identity);
        GameObject goPopUp = Instantiate(popUp, go.transform.position, Quaternion.identity);
        Destroy(go);
        Destroy(goParticle, 0.5f);
        Destroy(goPopUp, 1.5f);
    }

    public void resetPos(){
        this.transform.position = initPos;
    }

}

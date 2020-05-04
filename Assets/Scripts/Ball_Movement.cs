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
    bool jumpInput;
    Vector3 initPos;

    [Header("UI")]
    public GameObject score;
    public GameObject particulaItem;
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
        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        Move();

        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            if (jumpInput)
                Jump();

        }
    }

    void Move()
    {
        //myRigidbody.velocity = new Vector3(hInput * 3f * Time.fixedDeltaTime, myRigidbody.velocity.y, vInput * 3f * Time.fixedDeltaTime);
        myRigidbody.AddForce(hInput * Time.fixedDeltaTime, 0f, vInput * Time.fixedDeltaTime);
    }

    void Jump()
    {
        myRigidbody.AddForce(Vector3.up * jumpPower * Time.fixedDeltaTime, ForceMode.Impulse);

        FindObjectOfType<AudioManager>().BallJump();
    }


    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.CompareTag("Good Food")){
        
            GameObject particle = Instantiate(particulaItem, o.gameObject.transform.position, Quaternion.identity);
            GameObject popUp = Instantiate(popUpScore, o.gameObject.transform.position, Quaternion.identity);
            Destroy(o.gameObject);
            Destroy(particle, 0.5f);
            Destroy(popUp, 1.5f);

            score.GetComponent<Score>().atualizarScore();
        }
        else if (o.gameObject.CompareTag("Bad Food")) {

            GameObject particle = Instantiate(particulaItem, o.gameObject.transform.position, Quaternion.identity);
            GameObject popUp = Instantiate(popUpHP, o.gameObject.transform.position, Quaternion.identity);
            Destroy(o.gameObject);
            Destroy(particle, 0.5f);
            Destroy(popUp, 1.5f);
            FindObjectOfType<Health_Controller>().tomouDano();
        }
    }

    public void resetPos(){
        this.transform.position = initPos;
    }

}

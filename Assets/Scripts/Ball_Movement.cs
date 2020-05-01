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

    public GameObject particulaItem;
    private int pontos;
    public Text txtPontos;
    private bool podeganhar = false;

    // Start is called before the first frame update
    void Start()
    {
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
            {
                Jump();
            }

        }
    }

    void Move()
    {
        myRigidbody.AddForce(hInput * Time.fixedDeltaTime, 0f, vInput * Time.fixedDeltaTime);
    }

    void Jump()
    {
        myRigidbody.AddForce(Vector3.up * jumpPower * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.CompareTag("Item")){
            Instantiate(particulaItem, o.gameObject.transform.position, Quaternion.identity);
            Destroy(o.gameObject);
            pontos++;
            txtPontos.text = "Pontos: " + pontos.ToString();

            if (pontos >= 3 && pontos <= 5){
                podeganhar = true;
                Debug.Log("Pode Ganhar");
            }else{
                podeganhar = false;
                Debug.Log("Não pode ganhar ainda");
            }
        }
    }

}

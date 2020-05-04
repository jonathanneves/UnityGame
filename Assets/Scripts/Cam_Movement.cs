using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Movement : MonoBehaviour
{

    public Transform Target,Player;
    public  float RotationSpeed = 1;
    float MouseX;
    float MouseY;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {

        MouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        MouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        MouseY = Mathf.Clamp(MouseY, -40, 40);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(MouseY, MouseX, 0);
        Player.rotation = Quaternion.Euler(0, MouseX, 0);

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface_Displacement_1 : MonoBehaviour
{
    public float Speed = 10f;
    public float RotationSpeed = 10f;
    public float JumpSpeed = 10f;

    /* Acceso a componentes diferentes de Transform */
    private Rigidbody Physics;

    // Start is called before the first frame update
    void Start()
    {
        /* Bloquear el mouse en el centro  */
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Moviminetos de personaje */
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, 0.0f, y) * Time.deltaTime * Speed);
        /* Rotacición */
        float rotationY=Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));
        /* Salto */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }
}

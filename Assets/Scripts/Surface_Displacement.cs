using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface_Displacement : MonoBehaviour
{
    public float velocidad_desplazamiento = 5f;
    public float velocidad_rotacion = 100f;
    private Animator animator;
    public Rigidbody rb;
    /* Variables para reconocer si el personaje se mueve en planos X e Y */
    public float x, y;
    /* Variable para controlar el salto */
    public float fuerzaSalto;
    public bool puedeSaltar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        fuerzaSalto = 5f;
        puedeSaltar = false;
    }

    // FixedUpdate is called once per period time
    void FixedUpdate()
    {
        /* Comando para realizar desplazamientos */
        transform.Rotate(0, x * Time.deltaTime * velocidad_rotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidad_desplazamiento);
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        //Control de salto de la animacion
        if (puedeSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                animator.SetBool("Salte", true);
            }
            animator.SetBool("TocarSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }
    void EstoyCayendo()
    {
        animator.SetBool("TocarSuelo", false);
        animator.SetBool("Salte", false);
    }
}

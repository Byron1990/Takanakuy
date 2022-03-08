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
    /* Variables para agachado */
    public float velocidadInicial;
    public float velocidadAgachado;
    /* Variables para atacar */
    public bool estoyAtacado;
    public bool avanzaSolo;
    public float impulsoGolpe = 10f;
    // Start is called before the first frame update
    void Start()
    {
        /* Bloquear el mouse en el centro  */
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        fuerzaSalto = 5f;
        puedeSaltar = false;
        //Agachado
        velocidadInicial = velocidad_desplazamiento;
        velocidadAgachado = velocidad_desplazamiento / 2;
    }

    // FixedUpdate is called once per period time
    void FixedUpdate()
    {
        if (!estoyAtacado)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidad_rotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidad_desplazamiento);
        }
        /* Comando para realizar desplazamientos */
        transform.Rotate(0, x * Time.deltaTime * velocidad_rotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidad_desplazamiento);

        if (avanzaSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        /* Cuando activar el ataque */
        if (Input.GetMouseButtonDown(0) && puedeSaltar && !estoyAtacado)
        {
            Debug.Log("Ataque");
            animator.SetTrigger("Golpeo");
            estoyAtacado = true;
        }
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        //Control de salto de la animacion
        if (puedeSaltar)
        {
            if (!estoyAtacado)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                    animator.SetBool("Salte", true);
                }
                if (Input.GetKey(KeyCode.C))
                {
                    animator.SetBool("Agachado", true);
                    velocidad_desplazamiento = velocidadAgachado;
                }
                else
                {
                    animator.SetBool("Agachado", false);
                    velocidad_desplazamiento = velocidadInicial;
                }
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

    public void DejeDeAtacar()
    {
        estoyAtacado = false;
    }
    public void AvanzaSolo()
    {
        avanzaSolo = true;
    }
    public void DejaDeAvanzar()
    {
        avanzaSolo = false;
    }
}

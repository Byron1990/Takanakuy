using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface_Displacement : MonoBehaviour
{
    public float velocidad_desplazamiento = 5f;
    public float velocidad_rotacion = 100f;
    private Animator animator;
    /* Variables para reconocer si el personaje se mueve en planos X e Y */
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        /* Comando para realizar desplazamientos */
        transform.Rotate(0, x*Time.deltaTime*velocidad_rotacion,0);
        transform.Translate(0,0,y*Time.deltaTime*velocidad_desplazamiento);
    
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }
}

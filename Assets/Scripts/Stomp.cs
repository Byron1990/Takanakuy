using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    public BarraDeVida barraDeVida;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        //Si el personaje esta tocando una superficie puede saltar
        //surface_Displacement.puedeSaltar = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Atacando");
            barraDeVida.RecibirDaño(10);
        }
        //Si el personaje sale de la superficie no puede saltar
        //surface_Displacement.puedeSaltar = false;
    }
}

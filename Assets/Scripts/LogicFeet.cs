using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicFeet : MonoBehaviour
{
    public Surface_Displacement surface_Displacement;
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
        surface_Displacement.puedeSaltar = true;
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Pies toparon " + other.name);
        //Si el personaje sale de la superficie no puede saltar
        surface_Displacement.puedeSaltar = false;
    }
}

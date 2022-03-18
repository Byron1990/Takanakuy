using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Para usar las interfaces
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima=100;

    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

    public void RecibirDaño(float daño)
    {
        vidaActual -= daño;
    }
}

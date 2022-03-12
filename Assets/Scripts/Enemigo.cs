using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float crono;
    public Animator anim;
    public Quaternion angulo;
    public float grado;
    /* Objeto a perseguir */
    public GameObject target;
    public float dist = Math.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }

    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            anim.SetBool("correr", false);
            crono += 1 * Time.deltaTime;
            if (crono >= 4)
            {
                crono = 0;
                rutina = Random.Range(0, 2);
            }
            switch (rutina)
            {
                /* Enemigo se queda quieto */
                case 0:
                    anim.SetBool("caminar", false);
                    break;
                /* Se indica hacia donde caminará  */
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                /* Enemigo se mueve hacia el punto indicado */
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("caminar", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            anim.SetBool("caminar", false);
            anim.SetBool("correr", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
    }
}

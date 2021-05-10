using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerirColisoes : MonoBehaviour
{
    [SerializeField]
    int tiraVida = 10;
    [SerializeField]
    int intervalo = 3;
    [SerializeField]
    float ultimaVezQuePerdeuVida = 0;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        RetirarVida(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (ultimaVezQuePerdeuVida + intervalo < Time.time)
        {
            RetirarVida(other);
        }
    }

    // Update is called once per frame
    private void RetirarVida(Collider other)
    {
        var temp = other.transform.GetComponent<Saude>() as Saude;

        if (temp != null)
        {
            temp.retiraVida(tiraVida);
            ultimaVezQuePerdeuVida = Time.time;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarVida : MonoBehaviour
{
    [SerializeField]
    int valordeVida = 10;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            int vidaAtual = other.GetComponent<Saude>().GetVida();

            if(vidaAtual < 100)
            {
                other.GetComponent<Saude>().adicionaVida(valordeVida);
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
    }
}

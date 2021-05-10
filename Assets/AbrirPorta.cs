using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour
{
    [SerializeField]
    Transform pontoInicial;
    [SerializeField]
    Transform pontoFinal;

    public float incY = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pontoInicial.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 novaPosicao = transform.position;
        novaPosicao.y += incY * Time.deltaTime;
        transform.position = novaPosicao;

        if (incY > 0)
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoFinal.position)) < 0.1)
            {
                incY *= -1;
            }
        }
        else
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, pontoInicial.position)) < 0.1)
            {
                incY *= -1;
            }
        }

    }
}

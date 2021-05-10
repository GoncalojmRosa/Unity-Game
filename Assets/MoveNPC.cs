using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    [SerializeField]
    Transform[] pontos;

    public int proximoPonto = 0;

    [SerializeField]
    float velocidade;
    [SerializeField]
    float distanciaMinima = 5;
    [SerializeField]
    bool emMovimento = false;

    Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        if (pontos.Length == 0)
        {
            Debug.Log("Tem de indicar pontos a percorrer");
            return;
        }
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pontos.Length == 0)
        {
            Debug.Log("Tem de indicar pontos a percorrer");
            return;
        }
        //Debug.Log(Vector3.Distance(transform.position, pontos[proximoPonto].position));

        if (Vector3.Distance(transform.position, pontos[proximoPonto].position)<distanciaMinima)
        {
            proximoPonto++;
            if (proximoPonto > pontos.Length - 1)
            {
                proximoPonto = 0;
            }
        }

        Vector3 direcao = pontos[proximoPonto].position - transform.position;
        Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);

        transform.rotation = rotacao;
        _rigidBody.MovePosition(transform.position + (transform.forward * velocidade * Time.deltaTime));
    }
}

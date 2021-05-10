using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public float raioExplosao = 10.0f;
    public float forcaExplosao = 10.0f;
    public ParticleSystem efeitoExplosao;
    public int danoBomba = 50;
    // Start is called before the first frame update

    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Invoke("Explosao", 2);
    }

    // Update is called once per frame
    public void Explosao()
    {
        _audioSource.Play();

        Debug.Log("Explode");
        Vector3 posicaoExplode = transform.position;

        Collider[] colliders = Physics.OverlapSphere(posicaoExplode, raioExplosao);

        foreach(Collider obj in colliders)
        {
            if (obj is CharacterController) continue;

            Rigidbody rb = obj.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(forcaExplosao, posicaoExplode, raioExplosao, 3.0f);
            }
            Saude pl = obj.GetComponent<Saude>();

            if (pl != null)
            {
                pl.retiraVida(danoBomba);
            }
        }
        if(efeitoExplosao != null)
        {
            efeitoExplosao = Instantiate(efeitoExplosao, transform);
            efeitoExplosao.Play();
        }
        this.GetComponent<Renderer>().enabled = false;
        Destroy(this.gameObject, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saude : MonoBehaviour
{
    [SerializeField]
    int vida = 100;
    [SerializeField]
    AudioClip _somPerderVida;

    AudioSource _audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public int GetVida()
    {
        return vida;
    }

    // Update is called once per frame
    public void retiraVida(int valor)
    {
        vida -= valor;
        if (vida <= 0)
        {
            Destroy(this.gameObject);

        }
        var ovo = GetComponentInChildren<DropMe>();
        if (ovo != null)
        {

            ovo.gameObject.transform.parent = null;

            ovo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            ovo.gameObject.transform.position += Vector3.forward * 2;
        }

        if (_audioSource != null)
        {
            _audioSource.clip = _somPerderVida;
            _audioSource.Play();
        }
    }

    public void adicionaVida(int valor)
    {
        vida += valor;
    }
}

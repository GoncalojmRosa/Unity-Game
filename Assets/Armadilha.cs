using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rbDoCubo;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _rbDoCubo.useGravity = true;
        }
    }
}

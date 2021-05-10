using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMe : MonoBehaviour
{
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("DropPoint"))
        {
            //transform.GetComponent<Apanhar>().enabled = false;

            Destroy(GetComponent<Apanhar>());

            transform.parent = null;

            GetComponent<Rigidbody>().isKinematic = false;
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.adicionaOvo();

            Destroy(GetComponent<DropMe>());
        }
    }
}

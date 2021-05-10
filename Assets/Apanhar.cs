using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apanhar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (other.GetComponentInChildren<Apanhar>() == null)
            {
                transform.parent = other.transform;
                GetComponent<Rigidbody>().isKinematic = true;
            }

        }
    }
}

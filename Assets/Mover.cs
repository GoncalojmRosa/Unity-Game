using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
 
    public float velocityWalk = 5;
    public float velocityRotate = 5;

    CharacterController _characterController;

    public float inputAndar;
    public float inputRodar;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAndar = Input.GetAxis("Vertical");
        inputRodar = Input.GetAxis("Horizontal");

        Vector3 novaPosicao = transform.forward * velocityWalk * inputAndar;
        novaPosicao.y = Physics.gravity.y;

        _characterController.Move(novaPosicao * Time.deltaTime);

        _characterController.transform.Rotate(_characterController.transform.up * velocityWalk * inputRodar);
    }
}

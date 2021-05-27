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

    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAndar = Input.GetAxis("Vertical");
        inputRodar = Input.GetAxis("Horizontal");
        _animator.SetFloat("velocidade", inputAndar);

        Vector3 novaPosicao = transform.forward * velocityWalk * inputAndar;
        novaPosicao.y = Physics.gravity.y;

        _characterController.Move(novaPosicao * Time.deltaTime);

        _characterController.transform.Rotate(_characterController.transform.up * velocityWalk * inputRodar);
    }
}

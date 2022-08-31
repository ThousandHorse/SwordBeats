using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 0.01f;
    Animator animator;
    //[SerializeField] float jumpForce = 3;

    CharacterController _characterController;
    Transform _transform;
    Vector3 _moveVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = transform;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �ړ������Ƒ��x�w��
        _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

        // �ړ�
        _transform.position += _moveVelocity;
        //_characterController.Move(_moveVelocity * Time.deltaTime);



        // �v���C���[���ړ������Ɍ����悤�ɕύX����
        _transform.LookAt
            (_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

        // �A�j���[�V�����̐؂�ւ�
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackTrigger");
            
        }

        //Debug.Log($"moveSpeed: { animator.GetFloat("MoveSpeed")}");
        
    }
}

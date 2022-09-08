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
    private PlayerStatus _status;
    private MobAttack _attack;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = transform;
        _status = GetComponent<PlayerStatus>();
        _attack = GetComponent<MobAttack>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //animator.SetTrigger("AttackTrigger");
            Debug.Log("PlayerAttack");
            _attack.AttackIfPossible();

        }
        if (_status.IsMovable)
        {
            // �ړ������Ƒ��x�w��
            _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
            _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

            // �ړ�
            _transform.position += _moveVelocity;
          
            // �v���C���[���ړ������Ɍ����悤�ɕύX����
            _transform.LookAt
                (_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

            // �A�j���[�V�����̐؂�ւ�
            animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
        }
        else
        {
            _moveVelocity.x = 0;
            _moveVelocity.z = 0;
        }

    }
}
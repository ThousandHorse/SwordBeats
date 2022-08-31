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
        // 移動方向と速度指定
        _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

        // 移動
        _transform.position += _moveVelocity;
        //_characterController.Move(_moveVelocity * Time.deltaTime);



        // プレイヤーを移動方向に向くように変更する
        _transform.LookAt
            (_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

        // アニメーションの切り替え
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackTrigger");
            
        }

        //Debug.Log($"moveSpeed: { animator.GetFloat("MoveSpeed")}");
        
    }
}

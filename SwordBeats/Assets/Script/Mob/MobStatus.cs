using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal,
        Attack,
        Death
    }

    public bool IsMovable => StateEnum.Normal == _state;
    public bool IsAttackable => StateEnum.Normal == _state;
    public float LifeMax => lifeMax;
    public float Life => _life;

    int lifeMax = 3;
    int _life;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;

    [SerializeField] GameObject[] EnemyLife;


    protected virtual void Start()
    {
        _life = lifeMax;
        _animator = GetComponentInChildren<Animator>();
    }

    protected virtual void OnDeath()
    {

    }

    public void Damage(int damage)
    {

        if (_state == StateEnum.Death) return;

        _life -= damage;
        GetComponent<UIController>().decreaseLife(_life);
        Debug.Log("life: " + _life);
        if (_life > 0) return;

        _state = StateEnum.Death;
        _animator.SetTrigger("Death");
        OnDeath();
    }

    public void GoToAttackStateIfPossible()
    {
        Debug.Log("GoToAttackStateIfPossible");
        if (!IsAttackable) return;
        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }

    public void GoToNormalStateIfPossible()
    {
        Debug.Log("GoToAttackStateIfPossible");
        Debug.Log(_state);
        if (_state == StateEnum.Death) return;
        _state = StateEnum.Normal;
    }

}

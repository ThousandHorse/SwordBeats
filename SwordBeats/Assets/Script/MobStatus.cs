using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal,
        Attack,
        Death
    }

    public bool IsMovable => StateEnum.Normal == _state;
    public bool IsAttackable => StateEnum.Attack == _state;
    public float LifeMax => lifeMax;
    public float Life => _life;

    [SerializeField] float lifeMax = 10;
    float _life;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;


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
        if (_life > 0) return;

        _state = StateEnum.Death;
        _animator.SetTrigger("Death");
        OnDeath();
    }

    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;
        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }

    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Death) return;
        _state = StateEnum.Normal;
    }

}

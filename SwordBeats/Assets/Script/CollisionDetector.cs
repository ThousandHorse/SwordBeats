using System;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] TriggerEvent onTriggerStay = new TriggerEvent();
    [SerializeField] TriggerEvent onTriggerExit = new TriggerEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other);
    }

    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {

    }

}

using System;
using System.Collections;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static event Action OnChangedSpeed; 
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _acceleration;

    private void Awake()
    {
        StartCoroutine(AccelerationMap());
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * _speed * Time.fixedDeltaTime);
    }

    private IEnumerator AccelerationMap()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            _speed += _acceleration;
            OnChangedSpeed?.Invoke();
        }
    }
}
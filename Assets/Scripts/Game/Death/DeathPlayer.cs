using System;
using System.Collections;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    public static event Action OnDeath;
    [SerializeField] private LayerMask _letLayer;

    [SerializeField] private float _timeForDeath;
    public static bool checkIsDead { get; private set; }
    private RaycastHit _hit;

    private void Start()
    {
        checkIsDead = false;
    }

    private void Update()
    {
        if (transform.position.x < 3.5f) // Checking that player dont exit the Game Scene
        {
            OnDeath?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.right);
        if(Physics.Raycast(ray, out _hit, 0.3f, _letLayer))
        {
            StartCoroutine(InvokeDeath());
        }

        Debug.DrawRay(transform.position, transform.right, Color.red, 0.6f);
    }

    private IEnumerator InvokeDeath() // Wating for death
    {
        yield return new WaitForSeconds(0.5f);
        if (_hit.collider.gameObject.layer == _letLayer)
            OnDeath?.Invoke();
            checkIsDead = true;
    }
}

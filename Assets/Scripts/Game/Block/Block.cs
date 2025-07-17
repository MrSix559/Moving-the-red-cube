using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    public Rigidbody rb => _rb;
}

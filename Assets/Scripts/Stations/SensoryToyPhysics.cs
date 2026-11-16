using UnityEngine;

public class SensoryToyPhysics : MonoBehaviour
{
    [SerializeField] private float pushForce = 150f;
    [SerializeField] private float spinTorque = 50f;
    private Rigidbody2D _rb;

    private void Awake() => _rb = GetComponentInParent<Rigidbody2D>();

    private void OnTriggerEnter(Collider other)
    {
        Vector2 pushDir = (transform.position - other.transform.position).normalized;
        _rb.AddForce(pushDir * pushForce);
        _rb.AddTorque(spinTorque);
    }
}
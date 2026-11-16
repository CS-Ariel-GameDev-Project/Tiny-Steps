using UnityEngine;

[RequireComponent(typeof(ChildSensoryMeter))]
public class ChildCollisionReaction : MonoBehaviour
{
    [SerializeField] private float bumpStressPenalty = 15f;
    [SerializeField] private float minImpactSpeed = 0.5f;
    private ChildSensoryMeter _meter;

    private void Awake() => _meter = GetComponent<ChildSensoryMeter>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Inspect the collided object's tag and impact velocity
        if (collision.gameObject.CompareTag("Child") && collision.relativeVelocity.magnitude >= minImpactSpeed)
        {
            _meter.AddStress(bumpStressPenalty);
        }
    }
}
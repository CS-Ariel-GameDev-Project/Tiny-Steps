using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChildWander : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float directionChangeInterval = 2.5f;
    [SerializeField] private Vector2 roomBounds = new Vector2(6f, 3.5f);

    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private float _timer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        PickNewDirection();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= directionChangeInterval)
        {
            PickNewDirection();
        }
    }

    private void FixedUpdate()
    {
        // Keep the child inside the classroom boundaries
        Vector2 pos = transform.position;
        if (Mathf.Abs(pos.x) > roomBounds.x)
            _moveDirection.x = -Mathf.Sign(pos.x);
        if (Mathf.Abs(pos.y) > roomBounds.y)
            _moveDirection.y = -Mathf.Sign(pos.y);

        _rb.linearVelocity = _moveDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce away when bumping into another child or station
        PickNewDirection();
    }

    private void PickNewDirection()
    {
        _timer = 0f;
        _moveDirection = Random.insideUnitCircle.normalized;
    }
}
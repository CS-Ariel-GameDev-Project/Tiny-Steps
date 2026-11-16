using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TeacherController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float interactDistance = 1.5f;
    [SerializeField] private LayerMask interactableLayer;

    private CharacterController _controller;
    private Vector2 _lastMoveDir = Vector2.down;
    private SensoryAidData _heldAid;

    private void Awake() => _controller = GetComponent<CharacterController>();

    private void Update()
    {
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TryInteract();
        }
    }

    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(x, y, 0f).normalized;

        if (move.sqrMagnitude > 0.01f)
            _lastMoveDir = new Vector2(move.x, move.y);

        _controller.Move(move * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    private void TryInteract()
    {
        // Raycast requirement
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _lastMoveDir, interactDistance, interactableLayer);
        Debug.DrawRay(transform.position, _lastMoveDir * interactDistance, Color.yellow, 0.5f);

        if (hit.collider == null) return;

        if (hit.collider.TryGetComponent<AidDispenser>(out var dispenser))
        {
            _heldAid = dispenser.DispenseAid();
            Debug.Log($"Picked up: {_heldAid.aidName}");
        }
        else if (hit.collider.TryGetComponent<ChildNeedsHandler>(out var child) && _heldAid != null)
        {
            if (child.TryApplyAid(_heldAid))
            {
                Debug.Log($"Delivered {_heldAid.aidName}!");
                _heldAid = null;
            }
        }
    }
}
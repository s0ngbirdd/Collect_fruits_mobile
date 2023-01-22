using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    // Serialize
    [SerializeField] private float _conveyorSpeed = 0.2f;

    // Private
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ConveyorMove();
    }

    private void ConveyorMove()
    {
        Vector3 position = _rigidbody.position;
        _rigidbody.position += Vector3.back * _conveyorSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(position);
    }
}

using UnityEngine;

public class WakeUper : MonoBehaviour
{
    // Private
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        WakeUp();
    }

    private void WakeUp()
    {
        if (_rigidbody.IsSleeping())
        {
            _rigidbody.WakeUp();
        }
    }
}

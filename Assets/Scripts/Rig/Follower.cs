using UnityEngine;

public class Follower : MonoBehaviour
{
    // Serialize
    [SerializeField] private Transform _objectTransform;

    private void Start()
    {
        transform.position = _objectTransform.position;
    }
}

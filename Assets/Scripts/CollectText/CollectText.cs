using System.Collections;
using UnityEngine;

public class CollectText : MonoBehaviour
{
    // Serialize
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _timeBeforeDeactivate = 4.0f;

    // Private
    private Camera _camera;

    private void OnEnable()
    {
        StartCoroutine(WaitBeforeDeactivate());
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        LookTowardsCamera();
        MoveUp();
    }

    private void LookTowardsCamera()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
    }

    private IEnumerator WaitBeforeDeactivate()
    {
        yield return new WaitForSeconds(_timeBeforeDeactivate);

        gameObject.SetActive(false);
    }
}

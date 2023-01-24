using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    // Serialize
    [SerializeField] private Transform _handIKTarget;
    [SerializeField] private GameObject _aimTarget;
    [SerializeField] private Transform _handBone;

    // Private
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _handIKTarget.position = _aimTarget.transform.position;
            _animator.SetTrigger("GrabItem");
        }
    }

    private void OnAnimationGrabbedItem()
    {
        _aimTarget.transform.SetParent(_handBone, true);
    }

    private void OnAnimationStoredItem()
    {
        Destroy(_aimTarget);
    }
}

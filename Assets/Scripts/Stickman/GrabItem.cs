using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GrabItem : MonoBehaviour
{
    // Public
    public bool IsAnimationEnd { get; private set; }

    // Serialize
    [SerializeField] private Transform _handIKTarget;
    [SerializeField] private Transform _handBone;
    [SerializeField] private Transform _dropPoint;
    [SerializeField] private MultiAimConstraint _multiAimConstraint;

    // Private
    private Animator _animator;
    private GameObject _aimTarget;
    private float _targetWeight = 0.0f;

    private void Awake()
    {
        FruitPicker.OnFruitGrab.AddListener(SetAimTarget);

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SmoothChangeWeight();
    }

    private void SmoothChangeWeight()
    {
        _multiAimConstraint.weight = Mathf.Lerp(_multiAimConstraint.weight, _targetWeight, Time.deltaTime * 10.0f);
    }

    private void OnAnimationGrabbedItem()
    {
        _aimTarget.transform.position = _dropPoint.position;
        _targetWeight = 0.0f;
    }

    private void OnAnimationStoredItem()
    {
        _animator.SetTrigger("GrabItemEnd");
        IsAnimationEnd = true;
    }

    private void SetAimTarget(GameObject gameObject)
    {
        _aimTarget = gameObject;
        _handIKTarget.position = _aimTarget.transform.position;
        _animator.SetTrigger("GrabItem");
        _targetWeight = 1.0f;
        IsAnimationEnd = false;
    }
}

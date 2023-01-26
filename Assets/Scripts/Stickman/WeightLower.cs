using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeightLower : MonoBehaviour
{
    // Private
    private TwoBoneIKConstraint _twoBoneIKConstraint;

    private void Awake()
    {
        ObjectiveController.OnLevelComplete.AddListener(ChangeWeight);
        ObjectiveController.OnLevelFailed.AddListener(ChangeWeight);

        _twoBoneIKConstraint = GetComponent<TwoBoneIKConstraint>();
    }

    private void ChangeWeight()
    {
        _twoBoneIKConstraint.weight = 0.0f;
    }
}

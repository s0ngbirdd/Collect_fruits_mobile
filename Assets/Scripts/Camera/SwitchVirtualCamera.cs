using UnityEngine;

public class SwitchVirtualCamera : MonoBehaviour
{
    // Serialize
    [SerializeField] private GameObject _camera1;
    [SerializeField] private GameObject _camera2;

    private void Awake()
    {
        ObjectiveController.OnLevelComplete.AddListener(SwitchCamera);
        ObjectiveController.OnLevelFailed.AddListener(SwitchCamera);
    }

    private void SwitchCamera()
    {
        _camera2.SetActive(true);
        _camera1.SetActive(false);
    }
}

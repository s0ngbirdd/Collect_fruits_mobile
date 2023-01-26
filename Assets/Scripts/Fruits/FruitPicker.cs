using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitPicker : MonoBehaviour
{
    // Public
    public static UnityEvent<GameObject> OnFruitGrab = new UnityEvent<GameObject>();
    public static UnityEvent OnWrongFruitGrab = new UnityEvent();

    // Private
    private ObjectiveController _objectiveController;

    private void Start()
    {
        _objectiveController = FindObjectOfType<ObjectiveController>();
    }

    private void OnMouseOver()
    {
        CheckForObjectiveFruit();
    }

    private void CheckForObjectiveFruit()
    {
        if (Input.GetMouseButtonDown(0) && _objectiveController.RandomFruit.Equals(gameObject.tag))
        {
            AudioManager.Instance.PlayOneShot("Grab");
            OnFruitGrab?.Invoke(gameObject);

            _objectiveController.DecreaseNumber();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlayOneShot("No");
            OnWrongFruitGrab?.Invoke();
        }
    }
}

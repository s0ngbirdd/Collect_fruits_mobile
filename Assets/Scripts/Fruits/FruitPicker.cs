using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPicker : MonoBehaviour
{
    // Private
    private ObjectiveController _objectiveController;

    private void Start()
    {
        _objectiveController = FindObjectOfType<ObjectiveController>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && _objectiveController.RandomFruit.Equals(gameObject.tag))
        {
            AudioController.Instance.PlayOneShot("Grab");

            _objectiveController.DecreaseNumber();
            gameObject.SetActive(false);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            AudioController.Instance.PlayOneShot("No");
        }
    }
}

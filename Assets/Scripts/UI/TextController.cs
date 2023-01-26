using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    // Serialize
    [SerializeField] private TextMeshProUGUI _objectiveText;
    [SerializeField] private TextMeshProUGUI _timerText;

    // Private
    private ObjectiveController _objectiveController;

    private void Start()
    {
        _objectiveController = FindObjectOfType<ObjectiveController>();
    }

    private void Update()
    {
        DisplayObjective();
        DisplayTime();
    }

    private void DisplayObjective()
    {
        if (_objectiveController.RandomNumber > 1 && !_objectiveController.RandomFruit.Equals("PEACH"))
        {
            _objectiveText.text = "COLLECT " + _objectiveController.RandomNumber + " " + _objectiveController.RandomFruit + "S";
        }
        else if (_objectiveController.RandomNumber > 1 && _objectiveController.RandomFruit.Equals("PEACH"))
        {
            _objectiveText.text = "COLLECT " + _objectiveController.RandomNumber + " " + _objectiveController.RandomFruit + "ES";
        }
        else
        {
            _objectiveText.text = "COLLECT " + _objectiveController.RandomNumber + " " + _objectiveController.RandomFruit;
        }
    }

    private void DisplayTime()
    {
        _timerText.text = Mathf.Round(_objectiveController.Timer).ToString();
        _objectiveController.DecreaseTimer(Time.deltaTime);
    }
}

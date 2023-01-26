using UnityEngine;
using UnityEngine.Events;

public class ObjectiveController : MonoBehaviour
{
    // Public
    public static UnityEvent OnPickFruit = new UnityEvent();
    public static UnityEvent OnLevelComplete = new UnityEvent();
    public static UnityEvent OnLevelFailed = new UnityEvent();

    public string RandomFruit { get; private set; }
    public int RandomNumber { get; private set; }
    public float Timer { get; private set; } = 60.0f;

    // Private
    private string[] _fruits = { "APPLE", "PEACH", "LEMON" };
    private bool _isGameEnd;
    private GrabItem _grabItem;

    private void Start()
    {
        _grabItem = FindObjectOfType<GrabItem>();

        RandomFruit = _fruits[Random.Range(0, _fruits.Length)];
        RandomNumber = Random.Range(1, 6);

        Debug.Log(RandomFruit);
        Debug.Log(RandomNumber);
    }

    private void Update()
    {
        CheckLevelEnd();
    }

    private void CheckLevelEnd()
    {
        if (RandomNumber <= 0 && !_isGameEnd && _grabItem.IsAnimationEnd)
        {
            _isGameEnd = true;
            OnLevelComplete?.Invoke();
        }
        else if (Timer <= 0 && !_isGameEnd)
        {
            _isGameEnd = true;
            OnLevelFailed?.Invoke();
        }
    }

    public void DecreaseNumber()
    {
        RandomNumber--;
        OnPickFruit?.Invoke();
    }

    public void DecreaseTimer(float decreaseNumber)
    {
        Timer -= decreaseNumber;
    }
}

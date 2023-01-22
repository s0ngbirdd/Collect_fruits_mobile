using UnityEngine;

public class FruitPool : MonoBehaviour
{
    // Serialize
    [SerializeField] private int _poolCount = 5;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Apple _applePrefab;
    [SerializeField] private Peach _peachPrefab;
    [SerializeField] private Lemon _lemonPrefab;

    // Private
    private PoolMono<Apple> _applePool;
    private PoolMono<Peach> _peachPool;
    private PoolMono<Lemon> _lemonPool;

    private void Start()
    {
        _applePool = new PoolMono<Apple>(_applePrefab, _poolCount, transform);
        _applePool.AutoExpand = _autoExpand;

        _peachPool = new PoolMono<Peach>(_peachPrefab, _poolCount, transform);
        _peachPool.AutoExpand = _autoExpand;

        _lemonPool = new PoolMono<Lemon>(_lemonPrefab, _poolCount, transform);
        _lemonPool.AutoExpand = _autoExpand;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomFruit();
        }
    }

    private void CreateRandomFruit()
    {
        int randomIndex = Random.Range(0, 3);

        if (randomIndex == 0)
        {
            CreateApple();
        }
        else if (randomIndex == 1)
        {
            CreatePeach();
        }
        else if(randomIndex == 2)
        {
            CreateLemon();
        }
    }

    private void CreateApple()
    {
        var apple = _applePool.GetFreeElement();
        apple.transform.position = transform.position;
    }

    private void CreatePeach()
    {
        var peach = _peachPool.GetFreeElement();
        peach.transform.position = transform.position;
    }

    private void CreateLemon()
    {
        var lemon = _lemonPool.GetFreeElement();
        lemon.transform.position = transform.position;
    }
}

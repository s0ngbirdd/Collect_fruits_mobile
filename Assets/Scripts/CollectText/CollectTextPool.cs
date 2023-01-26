using UnityEngine;

public class CollectTextPool : MonoBehaviour
{
    // Serialize
    [SerializeField] private int _poolCount = 5;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private CollectText _collectTextPrefab;
    [SerializeField] private ParticleSystem _particleSystem;

    // Private
    private PoolMono<CollectText> _collectTextPool;

    private void Awake()
    {
        ObjectiveController.OnPickFruit.AddListener(CreateCollectText);
    }

    private void Start()
    {
        _collectTextPool = new PoolMono<CollectText>(_collectTextPrefab, _poolCount, transform);
        _collectTextPool.AutoExpand = _autoExpand;
    }

    private void CreateCollectText()
    {
        AudioManager.Instance.PlayOneShot("AddPoint");
        if (!_particleSystem.isPlaying)
        {
            _particleSystem.Play();
        }

        var collectText = _collectTextPool.GetFreeElement();
        collectText.transform.position = transform.position;
    }
}

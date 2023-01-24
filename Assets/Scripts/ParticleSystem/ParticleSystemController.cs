using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    // Serialize
    [SerializeField] private ParticleSystem _levelCompleteParticleSystem;
    [SerializeField] private ParticleSystem _levelFailedParticleSystem;

    private void Awake()
    {
        ObjectiveController.OnLevelComplete.AddListener(PlayLevelCompleteParticleSystem);
        ObjectiveController.OnLevelFailed.AddListener(PlayLevelFailedParticleSystem);
    }

    private void PlayLevelCompleteParticleSystem()
    {
        if (!_levelCompleteParticleSystem.isPlaying)
        {
            _levelCompleteParticleSystem.Play();
        }
    }

    private void PlayLevelFailedParticleSystem()
    {
        if (!_levelFailedParticleSystem.isPlaying)
        {
            _levelFailedParticleSystem.Play();
        }
    }
}

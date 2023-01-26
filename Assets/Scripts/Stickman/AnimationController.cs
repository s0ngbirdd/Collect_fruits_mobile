using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Private
    private Animator _animator;

    private void Awake()
    {
        ObjectiveController.OnLevelComplete.AddListener(PlayLevelCompleteAnimation);
        ObjectiveController.OnLevelFailed.AddListener(PlayLevelFailedAnimation);
        FruitPicker.OnWrongFruitGrab.AddListener(PlayWrongItemAnimation);

        _animator = GetComponent<Animator>();
    }

    private void PlayLevelCompleteAnimation()
    {
        _animator.SetTrigger("LevelComplete");
    }

    private void PlayLevelFailedAnimation()
    {
        _animator.SetTrigger("LevelFailed");
    }

    private void PlayWrongItemAnimation()
    {
        _animator.SetTrigger("WrongItem");
    }

    private void WrongItemEnd()
    {
        _animator.SetTrigger("WrongItemEnd");
    }
}

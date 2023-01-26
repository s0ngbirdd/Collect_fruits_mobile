using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    // Serialize
    [SerializeField] private GameObject _menuUI;
    [SerializeField] private TextMeshProUGUI _levelResultText;
    [SerializeField] private GameObject _objective;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _conveyor;
    [SerializeField] private GameObject _basket;

    private void Awake()
    {
        ObjectiveController.OnLevelComplete.AddListener(ShowCompleteMenuUI);
        ObjectiveController.OnLevelFailed.AddListener(ShowFailMenuUI);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ShowCompleteMenuUI()
    {
        AudioManager.Instance.PlayOneShot("LevelComplete");

        _levelResultText.text = "LEVEL PASSED";
        DeactivateObjects();
        _menuUI.SetActive(true);
    }

    private void ShowFailMenuUI()
    {
        AudioManager.Instance.PlayOneShot("LevelFailed");

        _levelResultText.text = "LEVEL FAILED";
        DeactivateObjects();
        _menuUI.SetActive(true);
    }

    private void DeactivateObjects()
    {
        _objective.SetActive(false);
        _timer.SetActive(false);
        _conveyor.SetActive(false);
        _basket.SetActive(false);
    }
}

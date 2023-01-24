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
        AudioController.Instance.PlayOneShot("LevelComplete");

        _levelResultText.text = "LEVEL COMPLETE";
        _objective.SetActive(false);
        _timer.SetActive(false);
        _conveyor.SetActive(false);
        _menuUI.SetActive(true);
    }

    private void ShowFailMenuUI()
    {
        AudioController.Instance.PlayOneShot("LevelFailed");

        _levelResultText.text = "LEVEL FAILED";
        _objective.SetActive(false);
        _timer.SetActive(false);
        _conveyor.SetActive(false);
        _menuUI.SetActive(true);
    }
}

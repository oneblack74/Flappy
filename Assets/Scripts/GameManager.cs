using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameActive = false;
    public bool IsGameActive
    {
        get { return isGameActive; }
    }

    [SerializeField] private PlayerController playerController;
    [SerializeField] private PipeManager pipeManager;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject gameInfo;

    [SerializeField] private TextMeshProUGUI textScoreInGame;
    [SerializeField] private TextMeshProUGUI textScoreInMenu;
    [SerializeField] private TextMeshProUGUI textHighScoreInMenu;
    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        isGameActive = false;
        pipeManager.GameOver();
        gameOverMenu.SetActive(true);
        textHighScoreInMenu.text = highScore.ToString();
        textScoreInMenu.text = score.ToString();
        gameInfo.SetActive(false);
    }

    public void RestartGame()
    {
        score = 0;
        textScoreInGame.text = score.ToString();
        playerController.gameObject.SetActive(true);
        playerController.RestartPlayerController();
        pipeManager.RestartPipeManager();
        gameOverMenu.SetActive(false);
        gameInfo.SetActive(true);
    }

    public void StartGame()
    {
        isGameActive = true;
        playerController.StartPlayer();
        pipeManager.StartPipeManager();
    }

    public void AddScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
        textScoreInGame.text = score.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

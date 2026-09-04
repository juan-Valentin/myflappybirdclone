using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    private const string HighScoreKey = "HighScore";
    
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject obstacleSpawner;
    
    [SerializeField] private TMP_Text scoreTextCounter;
    [SerializeField] private GameObject scoreLabel;
    [SerializeField] private TMP_Text currentScoreLabel;
    [SerializeField] private TMP_Text highScoreLabel;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip scoreClip;
    [SerializeField] private AudioClip gameOverClip;
    
    public int Score  { get; private set; }
    public int HighScore { get; private set; }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    private void OnDestroy()
    {
        if  (instance == this)
        {
            instance = null;
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        
        gameOverText.gameObject.SetActive(true);
        playButton.SetActive(true);
        
        // Update high score
        UpdateHighScore();

        scoreLabel.SetActive(true);
        currentScoreLabel.text = $"Current Score: {Score}";
        highScoreLabel.text = $"High Score: {HighScore}";
        
        audioSource.PlayOneShot(gameOverClip);
    }

    public void ResetScore()
    {
        Score = 0;
        scoreTextCounter.text = "0";
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        
        gameOverText.gameObject.SetActive(false);
        playButton.SetActive(false);
        scoreLabel.SetActive(false);
        
        // reset player position
        player.transform.position = new Vector3(-5f, 0f, 0f);
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        
        // Clear obstacles
        ClearObstacles();
        
        // Reset score
        scoreLabel.SetActive(false);
        ResetScore();
    }
    
    private void ClearObstacles()
    {
        foreach (var o in obstacleSpawner.GetComponentsInChildren<ObstacleMovement>())
        {
            Destroy(o.gameObject);
        }   
    }

    public void AddScore()
    {
        Score++;
        scoreTextCounter.text = Score.ToString();
        audioSource.PlayOneShot(scoreClip);
    }

    private void UpdateHighScore()
    {
        if (Score <= HighScore) return;
        HighScore = Score;
        PlayerPrefs.SetInt(HighScoreKey, HighScore);
        PlayerPrefs.Save();
    }
}

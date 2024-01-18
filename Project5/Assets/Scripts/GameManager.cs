using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    [SerializeField]
    private int score;
    [SerializeField]
    private int Lives;
    public bool isGameActive=false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI gameOverText;

    public GameObject titleScreen;
    public GameObject PauseScreen;
    public Button restartButton;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        score = 0;
        scoreText.text = "Score : " + score;
        LifeText.text = "Lives : " + Lives;

        titleScreen.gameObject.SetActive(false); 
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void ReduceLife()
    {
        Lives -= 1;
        if (Lives < 0)
        {
            Lives = 0;
        }
        LifeText.text = "Lives : " + Lives;
        if (Lives <= 0)
            GameOver();
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void whenPressedESC()
    {
        if (PauseScreen.activeInHierarchy)
        {
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            PauseScreen.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            whenPressedESC();
        }
    }
}

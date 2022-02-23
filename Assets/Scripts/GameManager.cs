using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    public bool isGameOver;

    public GameObject title;

    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        title.SetActive(false);

        UpdateScore(score);

        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int point)
    {
        score += point;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    } 

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

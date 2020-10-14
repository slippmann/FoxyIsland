using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public int score;

    private Text scoreBoard;

    public void Start()
    {
        scoreBoard = GameObject.FindWithTag("Score").GetComponent<Text>();
    }

    public void GameOver()
    {
        Reload();
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddPoints(int numberOfPoints)
    {
        score += numberOfPoints;
        scoreBoard.text = $"{score}";
    }
}

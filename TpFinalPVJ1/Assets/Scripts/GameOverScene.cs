using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScene : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public float maxSizeText;
    private float time;

    void Start()
    {
        StartCoroutine("GameOverSize");
        timeText.text = "Tiempo:" + time.ToString("F2");
    }
    void OnEnable()
    {
        time = PlayerPrefs.GetFloat("time");
    }
    IEnumerator GameOverSize()
    {
        for (float f = 0f; f <= 3; f += 0.005f)
        {
            gameOverText.fontSize += f;
            if (gameOverText.fontSize > maxSizeText)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                StartCoroutine("GameOverColor");
                break;
            }
            yield return null;
        }
    }

    IEnumerator GameOverColor()
    {
        for (float f = 0f; f <= 3; f += 0.01f)
        {
            Color color = gameOverText.color;
            color.g -= f * Time.deltaTime * 2;
            color.b -= f * Time.deltaTime * 2;
            gameOverText.color = color;
            yield return null;
        }

    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void restartButton(string level)
    {
        SceneManager.LoadScene(level);
        gameOverText.fontSize = 1;
        gameOverText.alpha = 0;
    }
}

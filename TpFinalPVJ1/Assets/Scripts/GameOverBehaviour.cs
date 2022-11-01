using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverBehaviour : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button resetButton;
    public Button _exitButton;
    public float maxSizeText;

    void Start()
    {
        StartCoroutine("GameOver");
    }

    IEnumerator GameOver()
    {
        for (float f = 0f; f <= 3; f += 0.01f)
        {
            Color color = gameOverText.color;
            gameOverText.fontSize += f;
            color.a += f*Time.deltaTime*2.5f;
            gameOverText.color = color;
            if(gameOverText.fontSize > maxSizeText)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            }
            yield return null;
        }
    }

    public void OnResetButton()
    {
        StartCoroutine("ChangeColorResetButton");
    }

    IEnumerator ChangeColorResetButton()
    {
        for (float f = 0f; f <= 1; f += 0.1f)
        {
            ColorBlock cb = resetButton.colors;
            Color color = resetButton.colors.normalColor;
            color.r = f*2;
            cb.normalColor = new Color(color.r, color.g, color.b,color.a);
            resetButton.colors = cb;
            yield return null;
        }
    }
    public void OnExitButton()
    {
        StartCoroutine("ChangeColorExitButton");
    }

    IEnumerator ChangeColorExitButton()
    {
        for (float f = 0f; f <= 1; f += 0.1f)
        {
            ColorBlock cb = _exitButton.colors;
            Color color = _exitButton.colors.normalColor;
            color.b = f*2;
            cb.normalColor = new Color(color.r, color.g, color.b, color.a);
            _exitButton.colors = cb;
            yield return null;
        }
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PlayerBehaviour playerBehaviour;
        playerBehaviour = new PlayerBehaviour();

        player.transform.position = new Vector3(playerBehaviour.initialX, playerBehaviour.initialY, playerBehaviour.initialZ);
        transform.eulerAngles = new Vector3(playerBehaviour.initialRotX, playerBehaviour.initialRotY, playerBehaviour.initialRotZ);
        */
        gameOverText.fontSize = 1;
        gameOverText.alpha = 0;
    }
}

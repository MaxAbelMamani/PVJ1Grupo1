using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionGame : MonoBehaviour
{
    [Header("Options")]
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;
    public Toggle screen;
    public TMP_Dropdown resolucion;
    Resolution[] resoluciones;
    [Header("Panels")]
    public GameObject optionsPanel;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Screen.fullScreen)
        {
            screen.isOn = true;
        }
        else
        {
            screen.isOn = false;
        }

        ComprobarResolucion();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsPanel.SetActive(true);
            PlaySoundButton();
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
    public void PantallaCompleta (bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void BackButton()
    {
        optionsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void ComprobarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucion.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0;i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolucion.AddOptions(opciones);
        resolucion.value = resolucionActual;
        resolucion.RefreshShownValue();
        resolucion.value = PlayerPrefs.GetInt("numeroResolucion",0);
    }
    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucion.value);
        Resolution indResolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(indResolucion.width, indResolucion.height, Screen.fullScreen);
    }
}
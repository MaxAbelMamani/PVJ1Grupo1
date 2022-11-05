using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;
    public Toggle screen;
    public TMP_Dropdown resolucion;
    Resolution[] resoluciones;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;

    void Start()
    {
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

 
    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void SetMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
       else
            mixer.SetFloat("VolMaster", lastVolume);
    }

    public void OpenPanel( GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }
    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
    public void PantallaCompleta (bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
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

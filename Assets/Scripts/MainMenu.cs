using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject optionsButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject creditsButton;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject creditsMenu;

    public AudioSource select;
    public void LoadScene(string name) //Esta funcion nos sirve para cargar todas las escenas que tengamos o lleguemos a tener
    {
        SceneManager.LoadScene("Cinematica");
        select.Play();
    }

    public void Quit()
    {
        Application.Quit();
        select.Play();
    }

    public void ShowOptionsMenu()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        exitButton.SetActive(false);
        creditsButton.SetActive(false);
        creditsMenu.SetActive(false);
        optionsMenu.SetActive(true);
        select.Play();
    }

    public void HideOptionsMenu()
    {
        playButton.SetActive(true);
        optionsButton.SetActive(true);
        creditsButton.SetActive(true);
        exitButton.SetActive(true);
        creditsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        select.Play();
    }

    public void ShowCreditsMenu()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        exitButton.SetActive(false);
        creditsButton.SetActive(false);
        creditsMenu.SetActive(true);
        optionsMenu.SetActive(false);
        select.Play();
    }

    public void HideCreditsMenu()
    {
        playButton.SetActive(true);
        optionsButton.SetActive(true);
        exitButton.SetActive(true);
        creditsButton.SetActive(true);
        creditsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        select.Play();
    }
}

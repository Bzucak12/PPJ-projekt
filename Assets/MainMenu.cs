using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Přidáno pro práci s UI

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    public AudioClip musicClip; // Zvuková stopa pro hlavní menu
    private AudioSource audioSource;
    void Start()
    {
        // Nastav kurzor na viditelný a odemčený
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
    }
    public void StartGame()
    {
        // Načti první úroveň hry
        SceneManager.LoadScene("Game");
    }

    public void ToMenu()
    {
        // Načti první úroveň hry
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        // Ukonči aplikaci
        Application.Quit();

        // Pro testování v editoru
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

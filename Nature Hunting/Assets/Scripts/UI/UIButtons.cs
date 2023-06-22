using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

     public Button pauseButton;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private GameObject gameObjectWithSound;
    private void Start()
    {
        gameObjectWithSound = GameObject.Find("UISound");
        _audioSource = gameObjectWithSound.GetComponent<AudioSource>();
        pausePanel.SetActive(false);
    }

    public void MenuLevelSceneButton()
    {
        StartCoroutine(MenuLevel());
    }
    private IEnumerator MenuLevel()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Menu");
    }


    public void LevelsOpenSceneButton()
   {
        StartCoroutine(Level());
   }
    private IEnumerator Level()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("MenuScene");
    }


    public void FreeShootingSceneButton()
    {
        StartCoroutine(FreeShooting());
    }
    private IEnumerator FreeShooting()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("FreeShooting");
    }

    public void FirstLevelSceneButton()
    {
        StartCoroutine(FirstLevel());
    }
    private IEnumerator FirstLevel()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("SampleScene");
    }


    public void SecondLevelSceneButton()
    {
        StartCoroutine(SecondLevel());
    }
    private IEnumerator SecondLevel()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("SecondLevel");
    }


    public void ThirdLevelSceneButton()
    {
        StartCoroutine(ThirdLevel());
    }
    private IEnumerator ThirdLevel()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("ThirdLevel");
    }


    public void ForthLevelSceneButton()
    {
        StartCoroutine(ForthLevel());
    }
    private IEnumerator ForthLevel()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("ForthLevel");
    }


    public void FifthLevelSceneButton()
    {
        StartCoroutine(FifthLevel());
    }
    private IEnumerator FifthLevel()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("FifthLevel");
    }


    public void SixthLevelSceneButton()
    {
        StartCoroutine(SixthLevel());
    }
    private IEnumerator SixthLevel()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("SixthLevel");
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        pauseButton.enabled = false;
    }
    public void ContinueButtton()
    {
        pausePanel.SetActive(false);
        pauseButton.enabled = true;
    }

    public void InstagramButton()
    {
        StartCoroutine(Inst());
    }
    private IEnumerator Inst()
    {
        _audioSource.PlayOneShot(_audio);
        yield return new WaitForSeconds(0.4f);
         Application.OpenURL("https://www.instagram.com/xdl_production/");
    }

}

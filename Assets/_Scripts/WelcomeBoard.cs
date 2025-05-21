using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeBoard : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadMenuScene());
    }

    private IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MenuScene");
    }
}
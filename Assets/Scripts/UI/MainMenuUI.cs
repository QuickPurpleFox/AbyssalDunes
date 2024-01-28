using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void StartGameButton()
    {
        SceneManager.LoadScene("DesertScene");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }
}

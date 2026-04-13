using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {

    }

    public void RestartGame()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(0);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public TMP_Text collectibleText;
    public TMP_Text collectibleValueTotal;
    private int collectibleNumberTotal;

    public static GameManager Instance { get; set; }

    private int collectibleValue;


    void Start()
    {
        Instance = this;
        collectibleNumberTotal = transform.childCount;
        collectibleValueTotal.text = collectibleNumberTotal.ToString();
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddCollectibles()
    {
        collectibleValue++;
        collectibleText.text = collectibleValue.ToString();
       
    }
    
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Musicmanager : MonoBehaviour
{
    public static Musicmanager instance; ///es el singleton de la clase

    public AudioClip levelMusic;

    private AudioSource audioSource;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Level1":
                audioSource.volume = 1f; //% del volumen
                PlayMusic(levelMusic);
                break;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip) return;
        audioSource.clip = clip;
        audioSource.Play();
    }


}

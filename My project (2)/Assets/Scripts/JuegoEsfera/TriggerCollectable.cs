using UnityEngine;

public class TriggerCollectable : MonoBehaviour
{
    public AudioSource sonidoMoneda;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger Collectible");
            GameManager.Instance.AddCollectibles();
            sonidoMoneda.Play(); //para que suene es solo esto
            Debug.Log("Sonido de moneda reproducido");
            Destroy(gameObject);
        }
    }
}

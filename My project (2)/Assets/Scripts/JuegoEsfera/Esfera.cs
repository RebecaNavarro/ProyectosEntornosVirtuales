using UnityEngine;
using UnityEngine.SceneManagement;

public class Esfera : MonoBehaviour
{
    public Rigidbody rb;
    public float velocidad = 10.0f;

    public AudioSource sonidoMoneda;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
      
    private void FixedUpdate()
    {
       float movimientoHorizontal = Input.GetAxis("Horizontal");
       float movimientoVertical = Input.GetAxis("Vertical");
        
        Vector3 direccion = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        if (direccion.magnitude > 1)
        {
            direccion = direccion.normalized;
        }

        Vector3 movimiento = new Vector3(movimientoHorizontal * velocidad, rb.linearVelocity.y, movimientoVertical * velocidad);

        // Debug.Log("Movimiento: " + movimiento.magnitude);

        rb.linearVelocity = movimiento;

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Collectible");
        GameManager.Instance.AddCollectibles();
        sonidoMoneda.Play(); //para que suene es solo esto
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //detecta cuando chocamos con el obstaculo
        if (collision.gameObject.CompareTag("Dead"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

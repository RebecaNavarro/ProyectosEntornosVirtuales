using UnityEngine;

public class Codo : MonoBehaviour
{

    public float velocidad = 2.0f;
    float anguloMinimo = 100f;
    float anguloMaximo = -180f;
    private float anguloAcumulado = 0f;

    void Start()
    {
        //Debug.Log("Codo iniciado");
    }

    
    void Update()
    {
        float movimiento = Mathf.PingPong(Time.time * velocidad, 1.0f);
        float anguloActual = Mathf.Lerp(anguloMinimo, anguloMaximo, movimiento);

        transform.localRotation = Quaternion.Euler(anguloActual, 0f, 0f);

        
        //anguloAcumulado += velocidad * Time.deltaTime;

       
        //anguloAcumulado %= 360;

        
        //transform.localRotation = Quaternion.Euler(anguloAcumulado, 0f, 0f);

    }
}

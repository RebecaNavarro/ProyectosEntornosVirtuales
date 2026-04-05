using UnityEngine;

public class GiroColindro : MonoBehaviour
{
    public float velocidadRotacion = 90f;

    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
        //delta time, tiempo que pasa en cada frame, independiente  de los recursos
        //time.deltatime es un tiempo entre frame y frame, no es el mismo para todos
        //time.time sincroniza para todos el tiempo
    }
}

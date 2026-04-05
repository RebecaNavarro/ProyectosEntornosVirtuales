using UnityEngine;
using System;

public class Manecillas : MonoBehaviour
{

    void Update()
    {
        DateTime tiempo = DateTime.Now;
        float rotacion = 0f;

        if (CompareTag("Horas")) 
        { 
            rotacion = (tiempo.Hour % 12 + tiempo.Minute / 60f) * 30f; 
        }
        else if (CompareTag("Minutos")) 
        { 
            rotacion = (tiempo.Minute + tiempo.Second / 60f) * 6f; 
        }

        transform.localRotation = Quaternion.AngleAxis(rotacion, Vector3.up);

    }
}

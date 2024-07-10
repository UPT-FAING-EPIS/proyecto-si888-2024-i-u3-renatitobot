using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objetivo a seguir (tu personaje)
    public Vector3 offset; // La distancia entre la c�mara y el personaje

    void Update()
    {
        // Actualiza la posici�n de la c�mara para que siga al objetivo con el offset especificado
        transform.position = target.position + offset;
    }
}

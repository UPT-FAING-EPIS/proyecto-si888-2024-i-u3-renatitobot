using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguntaActivator : MonoBehaviour
{
    public GameObject preguntaCanvas;
    public GameObject player;
    public GameObject objetoADestruir; // El objeto que se destruirá si la respuesta es correcta
    public GameManager gameManager;    // Referencia al GameManager para actualizar vidas e items

    private void Start()
    {
        if (preguntaCanvas != null)
        {
            preguntaCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("preguntaCanvas is not assigned!");
        }

        if (player == null)
        {
            Debug.LogError("Player is not assigned!");
        }

        if (gameManager == null)
        {
            gameManager = GameManager.instance;
            if (gameManager == null)
            {
                Debug.LogError("GameManager is not assigned!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called");
        if (other.gameObject == player)
        {
            Debug.Log("Player entered trigger");
            preguntaCanvas.SetActive(true);
            Time.timeScale = 0f; // Pausar el juego
        }
    }

    public void CorrectAnswer()
    {
        Debug.Log("CorrectAnswer called");
        preguntaCanvas.SetActive(false);  // Desactiva el canvas de la pregunta
        Time.timeScale = 1f;              // Restaura el tiempo de juego normal
        Destroy(objetoADestruir);         // Destruye el objeto que se debe eliminar

        // Decrementa el contador de items en el GameManager
        if (gameManager != null)
        {
            gameManager.ObjectCollected();
        }
        else
        {
            Debug.LogError("GameManager instance is not assigned!");
        }
    }

    public void WrongAnswer()
    {
        Debug.Log("WrongAnswer called");
        preguntaCanvas.SetActive(false);  // Desactiva el canvas de preguntas
        Time.timeScale = 1f;              // Reanuda el tiempo de juego

        if (gameManager != null)
        {
            // Llama al método en GameManager para reducir vidas
            gameManager.DecreaseLife();
        }
        else
        {
            Debug.LogError("GameManager instance is not assigned!");
        }
    }
}

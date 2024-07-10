using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket2 : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI messageText; // Referencia al texto para mostrar mensajes

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (GameManager.instance.items == 0)
            {
                ShowMessage("Felicidades! Has completado el juego.");
                StartCoroutine(EndGame());
            }
            else
            {
                ShowMessage("Recolecta los items faltantes");
            }
        }
    }

    private void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            StartCoroutine(HideMessageAfterDelay(3f)); // Ocultar el mensaje despu�s de 3 segundos
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.text = "";
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f); // Esperar 2 segundos antes de terminar el juego
        // Aqu� puedes agregar la l�gica para finalizar el juego, como mostrar una pantalla de cr�ditos o volver al men� principal
        // Por ejemplo, podr�as cargar una escena de pantalla de finalizaci�n:
        SceneManager.LoadScene("GameOverScreen"); // Aseg�rate de tener una escena llamada "EndGameScene" en tus build settings
    }
}

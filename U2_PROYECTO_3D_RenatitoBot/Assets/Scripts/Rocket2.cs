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
            StartCoroutine(HideMessageAfterDelay(3f)); // Ocultar el mensaje después de 3 segundos
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
        // Aquí puedes agregar la lógica para finalizar el juego, como mostrar una pantalla de créditos o volver al menú principal
        // Por ejemplo, podrías cargar una escena de pantalla de finalización:
        SceneManager.LoadScene("GameOverScreen"); // Asegúrate de tener una escena llamada "EndGameScene" en tus build settings
    }
}

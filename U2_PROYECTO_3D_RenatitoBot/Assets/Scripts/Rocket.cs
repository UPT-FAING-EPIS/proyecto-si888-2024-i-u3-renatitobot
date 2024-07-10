using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RocketController : MonoBehaviour
{
    public GameObject player;
    public string nextLevelSceneName; // Nombre de la siguiente escena
    public TextMeshProUGUI messageText; // Referencia al texto para mostrar mensajes

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (GameManager.instance.items == 0)
            {
                ShowMessage("Vamos a la siguiente zona");
                StartCoroutine(LoadNextLevel());
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

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2f); // Esperar 2 segundos antes de cambiar de nivel
        SceneManager.LoadScene(nextLevelSceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI itemsText;
    public TextMeshProUGUI messageText;

    // Método para actualizar el texto de vidas
    public void UpdateLivesText(int lives)
    {
        livesText.text = lives.ToString();
    }

    // Método para actualizar el texto de items
    public void UpdateItemsText(int items)
    {
        itemsText.text = items.ToString();
    }

    // Método para mostrar un mensaje en pantalla
    public void ShowMessage(string message)
    {
        messageText.text = message;
    }

    // Método para ocultar el mensaje
    public void HideMessage()
    {
        messageText.text = "";
    }
}

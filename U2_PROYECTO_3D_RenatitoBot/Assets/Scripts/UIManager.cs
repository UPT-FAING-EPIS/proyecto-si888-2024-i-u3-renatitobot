using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI itemsText;
    public TextMeshProUGUI messageText;

    // M�todo para actualizar el texto de vidas
    public void UpdateLivesText(int lives)
    {
        livesText.text = lives.ToString();
    }

    // M�todo para actualizar el texto de items
    public void UpdateItemsText(int items)
    {
        itemsText.text = items.ToString();
    }

    // M�todo para mostrar un mensaje en pantalla
    public void ShowMessage(string message)
    {
        messageText.text = message;
    }

    // M�todo para ocultar el mensaje
    public void HideMessage()
    {
        messageText.text = "";
    }
}

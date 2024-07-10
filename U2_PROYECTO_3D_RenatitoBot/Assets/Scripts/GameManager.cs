using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Variables accesibles desde fuera
    public int lives = 3;
    public int items = 4;

    // Referencia al UIManager
    public UIManager uiManager;

    // Nombre de la escena actual
    private string currentSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Obtener el nombre de la escena actual al inicio
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        // Inicializa los textos en el UIManager si está asignado
        if (uiManager != null)
        {
            uiManager.UpdateLivesText(lives);
            uiManager.UpdateItemsText(items);
        }
    }

    // Método para reducir vidas
    public void DecreaseLife()
    {
        lives--;
        if (uiManager != null)
        {
            uiManager.UpdateLivesText(lives);
        }

        if (lives <= 0)
        {
            RestartGame();
        }
    }

    // Método para notificar recolección de objetos
    public void ObjectCollected()
    {
        items--;
        if (uiManager != null)
        {
            uiManager.UpdateItemsText(items);
        }

        if (items == 0)
        {
            uiManager.ShowMessage("Vuelve a la nave");
        }
    }

    // Método para reiniciar el juego
    private void RestartGame()
    {
        // Reiniciar valores
        lives = 3;
        items = 4;
        if (uiManager != null)
        {
            uiManager.UpdateLivesText(lives);
            uiManager.UpdateItemsText(items);
            uiManager.HideMessage();
        }

        // Reiniciar la escena
        SceneManager.LoadScene(currentSceneName);
    }
}

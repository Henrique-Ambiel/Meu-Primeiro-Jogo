using UnityEngine;

// Classe responsável por gerenciar o estado geral do jogo
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instância estática para implementar o padrão Singleton (acesso global ao GameManager)
    public InputManager inputManager { get; private set; } // Gerenciador de inputs acessível publicamente, mas com set privado

    // Método chamado quando o GameObject é instanciado (antes do Start)
    void Awake()
    {
        if (instance != null) // Verifica se já existe uma instância do GameManager
            
            Destroy(this.gameObject); // Destroi esta nova instância para manter apenas uma no jogo

        instance = this; // Define esta instância como a principal (Singleton)
        inputManager = new InputManager(); // Cria uma nova instância do InputManager
    }
}


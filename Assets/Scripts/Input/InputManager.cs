using System;
using UnityEngine.InputSystem;

// Classe responsável por gerenciar os inputs do jogador
public class InputManager
{
    
    private PlayerControls playerControls; // Referência ao script gerado pelo sistema de Input da Unity (Input Actions)
    public float Movement => playerControls.Gameplay.Movement.ReadValue<float>();  // Propriedade para ler a direção de movimento do jogador (valor do eixo horizontal)
    public event Action onJump;  // Evento que será disparado quando o jogador pressionar o botão de pulo

    // Construtor do InputManager: inicializa os controles e conecta os eventos
    public InputManager()
    {
        
        playerControls = new PlayerControls(); // Instancia o esquema de controles
        playerControls.Gameplay.Enable(); // Ativa o mapa de controle Gameplay
        playerControls.Gameplay.Jump.performed += OnJumpPerformed; // Registra o método que será chamado quando o botão de pulo for pressionado
    }

    // Método chamado quando o botão de pulo é pressionado
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        // Dispara o evento de pulo (se houver algum ouvinte registrado)
        onJump?.Invoke();
    }
}

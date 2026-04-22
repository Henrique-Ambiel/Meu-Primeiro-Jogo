using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5; // Velocidade de movimento do jogador (editável pelo inspetor)
    [SerializeField] private float jumpForce = 6; // Força aplicada ao pulo (editável pelo inspetor)
    private Rigidbody2D rigidbody; // Referência ao Rigidbody2D para aplicar física no personagem
    private IsGroundedCheck isGroundedChecker; // Referência ao componente responsável por verificar se o jogador está no chão

    // Método chamado ao instanciar o objeto (antes do Start)
    private void Awake()
    {
       
        rigidbody = GetComponent<Rigidbody2D>(); // Pega o Rigidbody2D presente no GameObject
        isGroundedChecker = GetComponent<IsGroundedCheck>(); // Pega o script responsável por verificar se está no chão
    }

    // Método chamado no início do jogo (após Awake)
    private void Start()
    {
        // Registra o método de pulo no evento de input de pulo
        GameManager.instance.inputManager.onJump += HandleJump;
    }

    // Atualizado a cada frame
    private void Update()
    {
       
        float moveDirection = GameManager.instance.inputManager.Movement; // Pega a direção do movimento vinda do sistema de input
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, 0, 0); // Move o personagem horizontalmente com base na direção e velocidade

        if (moveDirection < 0)
        {
            transform.localScale = new Vector3((float)-0.7, (float)0.7, (float)0.7);
        }
        else
        {
            transform.localScale = new Vector3((float)0.7, (float)0.7, (float)0.7);
        }

    }

    // Método chamado quando o jogador pressiona o botão de pulo
    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded() == false) // Se o jogador não estiver no chão, não pula
            return;

        rigidbody.velocity += Vector2.up * jumpForce; // Aplica uma força vertical para simular o pulo
    }
}

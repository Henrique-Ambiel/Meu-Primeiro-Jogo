using UnityEngine;

// Script responsável por verificar se o jogador está tocando o chão
public class IsGroundedCheck : MonoBehaviour
{
    [SerializeField] private Transform checkerPosition; // Posição onde será feita a verificação (ponto central da checagem)
    [SerializeField] private Vector2 checkerSize; // Tamanho da área usada para verificar o contato com o chão
    [SerializeField] private LayerMask groundLayer; // Camada que define o que é considerado "chão"

    // Método que retorna true se o jogador estiver encostando no chão
    public bool IsGrounded()
    {
        // Cria uma caixa na posição e tamanho definidos, e verifica se colide com o chão
        return Physics2D.OverlapBox(checkerPosition.position, checkerSize, 0f, groundLayer);
    }

    // Método chamado pela Unity no editor para desenhar gizmos (ajuda visual na cena)
    private void OnDrawGizmos()
    {
        if (checkerPosition == null) // Se a posição de checagem não foi definida, sai do método
            return;

        if (IsGrounded()) // Define a cor do gizmo com base no estado atual (vermelho se no chão, verde se no ar)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        // Desenha uma caixa no editor representando a área de verificação
        Gizmos.DrawWireCube(checkerPosition.position, checkerSize);
    }
}

using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private IsGroundedCheck groundedCheck;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        groundedCheck = GetComponent<IsGroundedCheck>();

        Debug.Log("Animator: " + animator);
        Debug.Log("GroundedCheck: " + groundedCheck);
    }


    void Update()
    {
        float movement = GameManager.instance.inputManager.Movement;

        bool isWalking = Mathf.Abs(movement) > 0.01f; //Verifica se o player andou
        bool isJumping = !groundedCheck.IsGrounded();

        Debug.Log("isWalking: " + isWalking + " | movement: " + movement); //Testando se o personagem está andando

        animator.SetBool("isWalk", isWalking); //Inicia animação
        animator.SetBool("isJump", isJumping); //Inicia animação de pulo

        Debug.Log("GameManager: " + GameManager.instance); //Verifica se está instanciando o GameManager
        Debug.Log("InputManager: " + GameManager.instance?.inputManager); //Verifica se está instanciando o InputManager
    }
}

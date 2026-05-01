using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float movement = GameManager.instance.inputManager.Movement;

        bool isWalking = Mathf.Abs(movement) > 0.01f; //Verifica se o player andou

        Debug.Log("isWalking: " + isWalking + " | movement: " + movement); //Testando se o personagem está andando

        animator.SetBool("isWalk", isWalking); //Inicia animação
    }
}

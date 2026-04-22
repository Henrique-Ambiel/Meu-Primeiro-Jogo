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
        bool isWalking = GameManager.instance.inputManager.Movement != 0;

        animator.SetBool("isWalk", isWalking);
        
    }
}

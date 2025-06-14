using UnityEngine;

public class PlayerAnimator : MonoBehaviour

{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical");   

        
        Vector3 movement = new Vector3(h, 0f, v);

      
        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

       
        animator.SetFloat("Horizontal", h);
        animator.SetFloat("Vertical", v);

       
        animator.SetFloat("Speed", movement.magnitude);
    }
}

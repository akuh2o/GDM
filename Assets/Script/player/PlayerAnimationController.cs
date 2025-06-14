using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float smoothTime = 0.1f;
    private float currentHorizontal;
    private float currentVertical;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        currentHorizontal = Mathf.Lerp(currentHorizontal, horizontal, smoothTime);
        currentVertical = Mathf.Lerp(currentVertical, vertical, smoothTime);

        animator.SetFloat("Horizontal", currentHorizontal);
        animator.SetFloat("Vertical", currentVertical);

       
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("isCrouching", isCrouching);
    }
}

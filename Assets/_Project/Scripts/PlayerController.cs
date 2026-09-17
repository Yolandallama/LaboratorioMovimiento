using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 6f;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto = 14f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radioDeteccion = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;

    private float movimientoHorizontal;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Movimiento horizontal
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        // Detectar si el jugador está tocando el suelo
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            radioDeteccion,
            groundLayer
        );

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );
        }

        // -------------------------
        // CONTROL DE ANIMACIONES
        // -------------------------

        animator.SetBool(
            "isRunning",
            Mathf.Abs(movimientoHorizontal) > 0.01f
        );

        animator.SetBool(
            "isJumping",
            !isGrounded
        );
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            movimientoHorizontal * velocidad,
            rb.linearVelocity.y
        );
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(
                groundCheck.position,
                radioDeteccion
            );
        }
    }
}
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
    private float movimientoHorizontal;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            radioDeteccion,
            groundLayer
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );
        }
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
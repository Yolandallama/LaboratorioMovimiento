using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 6f;

    private Rigidbody2D rb;
    private float movimientoHorizontal;

    private void Awake()
    {
        // Obtiene el Rigidbody2D del personaje.
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Detecta izquierda y derecha con respuesta inmediata.
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // Aplica el movimiento horizontal conservando la velocidad vertical.
        rb.linearVelocity = new Vector2(
            movimientoHorizontal * velocidad,
            rb.linearVelocity.y
        );
    }
}

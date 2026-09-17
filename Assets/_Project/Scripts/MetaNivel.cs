using UnityEngine;

public class MetaNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Nivel completado!");

            // Detiene completamente al jugador.
            PlayerController controlador =
                collision.GetComponent<PlayerController>();

            if (controlador != null)
            {
                controlador.enabled = false;
            }

            Rigidbody2D rb =
                collision.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}
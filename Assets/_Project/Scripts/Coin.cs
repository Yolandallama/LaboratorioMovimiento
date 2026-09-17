using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoMoneda;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AgregarMoneda();

            AudioSource.PlayClipAtPoint(
                sonidoMoneda,
                transform.position
            );

            Destroy(gameObject);
        }
    }
}
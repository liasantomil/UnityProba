using UnityEngine;

public class PelotaBote : MonoBehaviour
{
    // Velocidad inicial de la pelota
    public float velocidad = 5f;

    // Fuerza de rebote
    public float rebote = 1.2f;

    // Componente Rigidbody de la pelota
    private Rigidbody rb;

    // Start se llama una vez al inicio
    void Start()
    {
        // Obtiene el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Asignamos una velocidad inicial al Rigidbody en una dirección aleatoria
        rb.velocity = new Vector3(velocidad, velocidad, velocidad);
    }

    // Update se llama una vez por cada frame
    void Update()
    {
        // Verificamos si la pelota se ha salido de los límites en X, Y o Z
        if (transform.position.x > 10 || transform.position.x < -10) // Límite en X
        {
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z); // Invertir velocidad X
        }

        if (transform.position.y > 10 || transform.position.y < 0) // Límite en Y
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z); // Invertir velocidad Y
        }

        if (transform.position.z > 10 || transform.position.z < -10) // Límite en Z
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z); // Invertir velocidad Z
        }
    }

    // Método que se llama cuando la pelota colisiona con otro objeto
    private void OnCollisionEnter(Collision col)
    {
        // Si la pelota toca algo, le damos un pequeño impulso para simular el rebote
        rb.velocity = rb.velocity * rebote;
    }
}

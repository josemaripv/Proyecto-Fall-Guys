using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_Persona : MonoBehaviour
{
    // Velocidad de movimiento del personaje.
    public float speed = 5f;

    // Velocidad de rotación del personaje.
    public float rotationSpeed = 10f;

    // Fuerza de salto del personaje.
    public float jumpForce = 5f;

    // Componente Rigidbody del personaje.
    private Rigidbody rb;

    // Posición inicial del personaje.
    private Vector3 posicionInicial;

    // Punto de respawn del personaje.
    public GameObject puntoRespawn;

    // Componente Animator del personaje.
    private Animator anim;

    // Referencia al script del HUD para gestionar las vidas.
    public HUD hdu;

    // Número de vidas del personaje.
    private int vidas = 3;

    // Indica si el salto ha sido iniciado.
    private bool saltoIniciado = false;

    // Método Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Obtener el componente Rigidbody al inicio.
        rb = GetComponent<Rigidbody>();

        // Almacenar la posición inicial del personaje.
        posicionInicial = transform.position;

        // Obtener el componente Animator al inicio.
        anim = GetComponent<Animator>();
    }

    // Método Update se llama una vez por frame.
    void Update()
    {
        // Obtener la entrada del teclado para el movimiento.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento.
        Vector3 moveDirection = new Vector3(-horizontalInput, 0f, -verticalInput).normalized;

        // Calcular la rotación del objeto.
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);

        // Mover el objeto en la dirección calculada.
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World); // Utiliza Space.World para mover en el mundo y no localmente.

        // Detener la rotación angular del Rigidbody.
        rb.angularVelocity = Vector3.zero;

        // Manejar el salto cuando se presiona el botón de salto.
        if (Input.GetButtonDown("Jump"))
        {
            // Reproducir sonido de salto.
            GetComponent<AudioSource>().Play();

            // Llamar al método Jump().
            Jump();
        }

        // Verificar si el personaje está corriendo para animación.
        bool Running = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));

        // Actualizar el parámetro de animación "Running".
        if (Running)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    // Método para manejar el salto del personaje.
    void Jump()
    {
        // Verificar si el salto no ha sido iniciado.
        if (!saltoIniciado)
        {
            // Obtener el componente Rigidbody del personaje.
            Rigidbody rb = GetComponent<Rigidbody>();

            // Verificar que el componente Rigidbody no sea nulo.
            if (rb != null)
            {
                // Aplicar fuerza hacia arriba para simular el salto.
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                // Marcar que el salto ha sido iniciado.
                saltoIniciado = true;
            }
        }
    }

    // Método para gestionar la pérdida de vida del personaje.
    public void PerderVida()
    {
        // Decrementar el número de vidas.
        vidas -= 1;

        // Desactivar un ícono de vida en el HUD.
        hdu.DesactivarVida(vidas);

        // Verificar si el número de vidas ha llegado a cero.
        if (vidas <= 0)
        {
            // Desbloquear el cursor y hacerlo visible.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Cargar la escena de Game Over.
            SceneManager.LoadScene("Derrota");
        }
    }

    public bool suelo()
    {
        // Utiliza un Raycast desde la posición actual hacia abajo para detectar el suelo.
        // Si el Raycast golpea algo a una distancia de hasta 0.1 unidades, se considera que está en el suelo.
        bool suelo = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Si la variable 'suelo' es verdadera, significa que está en el suelo, por lo que se devuelve 'true'.
        if (suelo)
        {
            return true;
        }
        // Si la variable 'suelo' es falsa, significa que no está en el suelo, por lo que se devuelve 'false'.
        else
        {
            return false;
        }
    }

    // Método llamado cuando el objeto colisiona con otro objeto.
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar las etiquetas de los objetos con los que colisiona.

        if (collision.gameObject.CompareTag("PlanoInvisible"))
        {
            // Reiniciar la posición del personaje al plano invisible.
            transform.position = posicionInicial;

            // Llamar al método para gestionar la pérdida de vida.
            PerderVida();
        }
        if (collision.gameObject.CompareTag("Plano2"))
        {
            // Mover al personaje al punto de respawn.
            transform.position = puntoRespawn.transform.position;

            // Llamar al método para gestionar la pérdida de vida.
            PerderVida();
        }
        if (collision.gameObject.CompareTag("Pala"))
        {
            // Mover al personaje al punto de respawn.
            transform.position = puntoRespawn.transform.position;

            // Llamar al método para gestionar la pérdida de vida.
            PerderVida();
        }
        if (collision.gameObject.CompareTag("Corona"))
        {
            // Desbloquear el cursor y hacerlo visible.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Cargar la escena de victoria.
            SceneManager.LoadScene("Win");
        }

        // Verificar si hay contactos de colisión.
        if (collision.contacts.Length > 0)
        {
            // Marcar que el salto puede iniciarse nuevamente si hay colisión.
            saltoIniciado = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_Persona : MonoBehaviour
{
    // Velocidad de movimiento del personaje.
    public float speed = 5f;

    // Velocidad de rotaci�n del personaje.
    public float rotationSpeed = 10f;

    // Fuerza de salto del personaje.
    public float jumpForce = 5f;

    // Componente Rigidbody del personaje.
    private Rigidbody rb;

    // Posici�n inicial del personaje.
    private Vector3 posicionInicial;

    // Punto de respawn del personaje.
    public GameObject puntoRespawn;

    // Componente Animator del personaje.
    private Animator anim;

    // Referencia al script del HUD para gestionar las vidas.
    public HUD hdu;

    // N�mero de vidas del personaje.
    private int vidas = 3;

    // Indica si el salto ha sido iniciado.
    private bool saltoIniciado = false;

    // M�todo Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Obtener el componente Rigidbody al inicio.
        rb = GetComponent<Rigidbody>();

        // Almacenar la posici�n inicial del personaje.
        posicionInicial = transform.position;

        // Obtener el componente Animator al inicio.
        anim = GetComponent<Animator>();
    }

    // M�todo Update se llama una vez por frame.
    void Update()
    {
        // Obtener la entrada del teclado para el movimiento.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la direcci�n del movimiento.
        Vector3 moveDirection = new Vector3(-horizontalInput, 0f, -verticalInput).normalized;

        // Calcular la rotaci�n del objeto.
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);

        // Mover el objeto en la direcci�n calculada.
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World); // Utiliza Space.World para mover en el mundo y no localmente.

        // Detener la rotaci�n angular del Rigidbody.
        rb.angularVelocity = Vector3.zero;

        // Manejar el salto cuando se presiona el bot�n de salto.
        if (Input.GetButtonDown("Jump"))
        {
            // Reproducir sonido de salto.
            GetComponent<AudioSource>().Play();

            // Llamar al m�todo Jump().
            Jump();
        }

        // Verificar si el personaje est� corriendo para animaci�n.
        bool Running = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));

        // Actualizar el par�metro de animaci�n "Running".
        if (Running)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    // M�todo para manejar el salto del personaje.
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

    // M�todo para gestionar la p�rdida de vida del personaje.
    public void PerderVida()
    {
        // Decrementar el n�mero de vidas.
        vidas -= 1;

        // Desactivar un �cono de vida en el HUD.
        hdu.DesactivarVida(vidas);

        // Verificar si el n�mero de vidas ha llegado a cero.
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
        // Utiliza un Raycast desde la posici�n actual hacia abajo para detectar el suelo.
        // Si el Raycast golpea algo a una distancia de hasta 0.1 unidades, se considera que est� en el suelo.
        bool suelo = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Si la variable 'suelo' es verdadera, significa que est� en el suelo, por lo que se devuelve 'true'.
        if (suelo)
        {
            return true;
        }
        // Si la variable 'suelo' es falsa, significa que no est� en el suelo, por lo que se devuelve 'false'.
        else
        {
            return false;
        }
    }

    // M�todo llamado cuando el objeto colisiona con otro objeto.
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar las etiquetas de los objetos con los que colisiona.

        if (collision.gameObject.CompareTag("PlanoInvisible"))
        {
            // Reiniciar la posici�n del personaje al plano invisible.
            transform.position = posicionInicial;

            // Llamar al m�todo para gestionar la p�rdida de vida.
            PerderVida();
        }
        if (collision.gameObject.CompareTag("Plano2"))
        {
            // Mover al personaje al punto de respawn.
            transform.position = puntoRespawn.transform.position;

            // Llamar al m�todo para gestionar la p�rdida de vida.
            PerderVida();
        }
        if (collision.gameObject.CompareTag("Pala"))
        {
            // Mover al personaje al punto de respawn.
            transform.position = puntoRespawn.transform.position;

            // Llamar al m�todo para gestionar la p�rdida de vida.
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

        // Verificar si hay contactos de colisi�n.
        if (collision.contacts.Length > 0)
        {
            // Marcar que el salto puede iniciarse nuevamente si hay colisi�n.
            saltoIniciado = false;
        }
    }
}
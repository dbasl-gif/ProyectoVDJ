using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 4;
    public float rotationSpeed = 10;
    //el objeto rota hacia arriba y abajo
    public Transform pivot;
    // guarda la rotacion en el eje x que necesita el pivote para mira arriba y abajo
    

    public float JumpForce = 10;
    
    private float xrotationPivot;

    Vector3 input;

    Rigidbody rb;

    private GroundCheker groundCheker;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        groundCheker = GetComponent<GroundCheker>();
    }

    // Update is called once per frame
    void Update()
    {
        //guardar el valor de movimiento en los ejes X Z
        input = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))).normalized;
        
        //hay que cambiar el vector de input para que sea relativo al tranform del jugador y siempre se mueva segun hacia donde esta mirando y no relativo al mundo
        input = transform.TransformDirection(input);



        if (Input.GetButtonDown("Jump") && groundCheker.IsGrounded == true) 
        {

            rb.AddForce(Vector3.up * JumpForce,ForceMode.VelocityChange);
        }

        //Rotacion horizontal
        transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * rotationSpeed, 0));

        //Al valor actual de rotacion le sumamos o restamos segun si subimos o bajamos el raton
        xrotationPivot -= Input.GetAxisRaw("Mouse Y") * rotationSpeed;

        //Limite de rotacion 
        xrotationPivot = Mathf.Clamp(xrotationPivot, -90, 90);
        
        //Actualizar los angulos de rotacion del pivote para que su rotacion en X sea la que hemos calculado con el raton.
        pivot.localEulerAngles = new Vector3(xrotationPivot,0,0);



    }

    private void FixedUpdate()
    {
        Vector3 movement = input.normalized * movementSpeed;

        movement.y = rb.linearVelocity.y;

        rb.linearVelocity = movement;
    }


}

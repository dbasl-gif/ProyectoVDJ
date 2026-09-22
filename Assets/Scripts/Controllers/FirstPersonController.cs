using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //guardar el valor de movimiento en los ejes X Z
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += input * movementSpeed * Time.deltaTime;
    }
}

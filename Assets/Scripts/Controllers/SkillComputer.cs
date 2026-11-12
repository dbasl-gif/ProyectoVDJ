
using UnityEngine;

public class SkillComputer : MonoBehaviour
{
    [Header("Configuracion")]
    public GameObject panelHabilidades;
    public Camera playerCamera;
    public float distanciaInteraccion = 3f;

    [Header("Jugador")]
    public FirstPersonController jugador;

    private bool menuAbierto = false;

    void Start()
    {
        panelHabilidades.SetActive(false);
    }

    void Update()
    {
        if (menuAbierto)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CerrarHabilidades();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(
                playerCamera.transform.position,
                playerCamera.transform.forward
            );

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaInteraccion))
            {
                if (hit.transform == transform ||
                    hit.transform.IsChildOf(transform))
                {
                    AbrirHabilidades();
                }
            }
        }
    }

    void AbrirHabilidades()
    {
        menuAbierto = true;
        panelHabilidades.SetActive(true);

        jugador.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CerrarHabilidades()
    {
        menuAbierto = false;
        panelHabilidades.SetActive(false);

        jugador.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

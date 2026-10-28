
using UnityEngine;

public class GroundCheker : MonoBehaviour
{
    public bool IsGrounded = false;

    [SerializeField] private Vector3 boxSize = new Vector3(0.5f, 0.2f, 0.5f);
    [SerializeField] private Vector3 offset = new Vector3(0, -0.5f, 0);
    [SerializeField] private LayerMask groundLayers;

    void FixedUpdate()
    {
        IsGrounded = Physics.CheckBox(
            transform.position + offset,
            boxSize * 0.5f,
            Quaternion.identity,
            groundLayers
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.peru;
        Gizmos.DrawWireCube(transform.position + offset, boxSize);
    }
}

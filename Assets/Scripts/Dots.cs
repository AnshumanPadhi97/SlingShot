using UnityEngine;

public class Dots : MonoBehaviour
{
    public float gravity;
    public Vector3 planetPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gravity = collision.GetComponent<PlanetGravity>().gravity;
        planetPos = collision.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gravity = 0;
    }
}

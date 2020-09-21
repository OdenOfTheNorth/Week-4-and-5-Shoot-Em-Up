using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shield _shield = other.GetComponent<Shield>();
            _shield._activateShireld = true;
            Destroy(gameObject);
        }
    }
}

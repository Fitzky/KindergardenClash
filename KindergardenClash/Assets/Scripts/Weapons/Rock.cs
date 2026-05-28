using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //DEAL DAMAGE TO ENEMY
            Debug.Log("Hit Enemy for " + damage + " damage!");
        }
    }
}

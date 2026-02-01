using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public ObjectPooler bulletPooler;
    public Transform shootPoint;
    public float bulletSpeed = 10f;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Shoot");
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 shootDirection = Vector2.right;

        GameObject bullet = bulletPooler.GetPooledBullet();
        bullet.transform.position = shootPoint.position;
        bullet.SetActive(true);

        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public AudioSource ShootSound;
    public Animator animator;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction ShootAction;
   
    GameObject bullet;

    private void Awake()
    {
        ShootAction = playerInput.actions["Shoot"];
    }

    private void OnEnable()
    {

        ShootAction.performed += _ => ShootStart();

    }
    private void OnDisable()
    {
        ShootAction.performed += _ => ShootStart();
    }

    void ShootStart()
    {
        Shoot();
        if (ShootSound != null)
        {
            ShootSound.Play();
        }

    }

    private void Shoot()
    {
        bullet = BulletObjectPool.SharedInstance.GetPooledBullet();  //Activates bullet if one is aviable on the object pool

        if (bullet != null && this != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().Project(transform.up);
        }

        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }
    }
}

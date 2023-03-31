using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public AudioSource ShootSound;
    public Animator animator;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction ShootAction;

    public Bullet bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        ShootAction = playerInput.actions["Shoot"];
    }

    private void OnEnable()
    {

        ShootAction.performed += _ => ShootStart();
        ShootAction.canceled += _ => ShootStop();

    }
    private void OnDisable()
    {

        ShootAction.performed += _ => ShootStart();
        ShootAction.canceled += _ => ShootStop();

    }

    void ShootStart()
    {
        Shoot();
        ShootSound.Play();
    }

    void ShootStop()
    {

    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Project(transform.up);
        animator.SetTrigger("Shoot");

    }
}

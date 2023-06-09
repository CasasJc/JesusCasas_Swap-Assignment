using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
   // public Animator animator;

    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;
    public float maxLifetime = 10f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rigidbody.AddForce(direction * speed);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Disables bullet to return to object pool when colliding with everything - Emilie
        this.gameObject.SetActive(false);
    }

}

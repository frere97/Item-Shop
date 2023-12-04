using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static LocalPlayer instance;
     [SerializeField] PlayerInventory inventory;
    [SerializeField] Rigidbody2D rb;
    public float speed = 1;
    Vector2 Movement;
    [SerializeField] Animator animator;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one localPlayer. Destroying the others to keep only one Instance");
            Destroy(instance.gameObject);
            
        }
        instance = this;

        if(inventory == null)
        {
            inventory = new PlayerInventory();
        }

        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    public Vector2 GetPlayerMovement()
    {
        return Movement;
    }

    public PlayerInventory GetInventory()
    {
        return inventory;
    }

    private void Update()
    {
        if(Movement.x == 0) { 
        Movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            Movement.y = 0;
        }
        if (Movement.y == 0) { 
        Movement.x = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            Movement.x = 0;
        }
        animator.SetFloat("Horizontal", Movement.x);
        animator.SetFloat("Vertical", Movement.y);
        animator.SetFloat("Speed", Movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * speed * Time.deltaTime);
    }
}

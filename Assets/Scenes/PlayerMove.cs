using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float x = 0;
    float y = 0;
    private Vector3 StartPosition = new Vector3(0, 0, 0);
    Vector3 dir = Vector3.zero;
    public float speed;
    public float BoundForce;
    public GameObject PlayerSkin;
    [SerializeField] Rigidbody2D rb = new Rigidbody2D();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float applySpeed = speed * Time.deltaTime;
        SetDirection();
        dir += new Vector3(x, y, 0).normalized * applySpeed;
        //PlayerSkin.transform.Rotate(0,0, -x *100* Time.deltaTime);
        rb.velocity = dir;
    }

    void SetDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            y = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            y = -1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            x = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x = -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            dir = new Vector3(0, 0, 0);
            dir += new Vector3(-x, y, 0).normalized * BoundForce * speed * Time.deltaTime;
            x *= 0;
            y *= 0;
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            dir = new Vector3(0, 0, 0);
            dir += new Vector3(x, -y, 0).normalized * BoundForce * speed * Time.deltaTime;
            x = 0;
            y = 0;
        }
    }
}

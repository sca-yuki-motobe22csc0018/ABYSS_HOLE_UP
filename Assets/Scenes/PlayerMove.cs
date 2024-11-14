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
    public float PowerMaxTime;
    float PowerTimer;
    // Start is called before the first frame update
    void Start()
    {
        PowerTimer = 0;
        rb = GetComponent<Rigidbody2D>();
        this.transform.position = StartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&PowerTimer<PowerMaxTime)
        {
            PowerTimer += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            PowerTimer = 0;
        }
        // マウスのスクリーン座標を取得
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2DなのでZ座標は無視

        // オブジェクトの位置からマウスの位置までのベクトルを計算
        Vector2 direction = mousePosition - transform.position;

        // ベクトルの角度を取得して回転させる
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        PlayerSkin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (PlayerSkin.transform.rotation.z > 0.7f || PlayerSkin.transform.rotation.z < -0.7f)
        {
            PlayerSkin.transform.localScale = new Vector3(-0.5f, -0.5f, 1);
        }
        else
        {
            PlayerSkin.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {/*
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
     */
    }
}

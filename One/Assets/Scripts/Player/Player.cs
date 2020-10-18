using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Joystick joystickMovement;
    [SerializeField]
    private Joystick joystickRotation;
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireRate;
    private float canFire;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        rb.velocity = new Vector2(joystickMovement.Horizontal,joystickMovement.Vertical) * speed * Time.fixedDeltaTime;

        float x = joystickRotation.Horizontal;
        float y = joystickRotation.Vertical;

        float angle = Mathf.Atan2(y,x) * 180 / Mathf.PI;

        pivot.rotation = Quaternion.Euler(0,0,angle);
        
        if ((Mathf.Abs(joystickRotation.Horizontal) > 0.5 || Mathf.Abs(joystickRotation.Vertical) > 0.5) && Time.time > canFire)
        {
            canFire = Time.time + fireRate;
            Instantiate(bullet, firePoint.position, pivot.rotation);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingToCursorController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}

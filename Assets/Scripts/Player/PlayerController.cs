using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float rotateSpeed;

    private Camera cam;
    private Vector3 dir;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Movement();
        Anim();
    }

    private void Anim()
    {
        //run
        if (Input.GetMouseButtonDown(0)) animator.SetBool("run", true);
        if (Input.GetMouseButtonUp(0)) animator.SetBool("run", false);
    }

    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
                dir = ray.GetPoint(distance);

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(dir.x, 0f, dir.z), playerSpeed * Time.deltaTime);

            var offset = dir - transform.position;

            if (offset.magnitude > 1f)
                transform.LookAt(dir);
        }
    }
}
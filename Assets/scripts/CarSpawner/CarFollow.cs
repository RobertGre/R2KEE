using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject Car;
    public float speed;

    private bool hasReachedSphere = false;

    void Start()
    {
        Sphere = GameObject.FindGameObjectWithTag("EndPoint");
    }

    void Update()
    {
        if (!hasReachedSphere)
        {
            CarTransform();
        }
    }

    void CarTransform()
    {
        // Move the car towards the sphere
        Car.transform.position = Vector3.MoveTowards(Car.transform.position, Sphere.transform.position, speed * Time.deltaTime);

        // Check if the car has reached the sphere's position
        if (Car.transform.position == Sphere.transform.position)
        {
            // Set the flag to indicate that the car has reached the sphere
            hasReachedSphere = true;
            Destroy(gameObject);
           
        }
    }
}

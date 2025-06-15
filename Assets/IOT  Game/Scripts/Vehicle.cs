using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private Transform[] pathPoints;
    [SerializeField] float speed = 2f;
    [SerializeField] int maxLaps = 3;
    [SerializeField] private float rotationSpeed = 2f;

    [SerializeField] GameObject destination;
    private int currentPointIndex = 0;
    private int currentLaps=0;
    private bool isActive = true;



    void Update()
    {
        if (pathPoints.Length == 0) return;

        Transform targetPoint = pathPoints[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        Vector3 direction = targetPoint.position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= pathPoints.Length)
                currentPointIndex = 0; // أو خليها stop لو مش عايزة تعيد
        }
    }




private void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;

        if (other.transform == destination)
        {


            Destroy(gameObject);
            GameControllerForGates.instance.AddScore(10);
        }
        else
        {
            isActive = false;
            Destroy(gameObject, 2f);
            GameControllerForGates.instance.AddScore(-5);
        }
        if (currentLaps >= maxLaps)

        {
            isActive = false;
        }
        else if (other.CompareTag("LapTrigger"))
        {
            currentLaps++;
            Debug.Log("Lap: " + currentLaps);



        }
    }


 }

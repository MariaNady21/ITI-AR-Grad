using UnityEngine;

public class CircularCarMovement : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 5f;
    public float speed = 1f;
    public Scorenum script;
    public Transform destinationoffice;
    public Transform destinationfactory;
    public Transform destinationwarehouse;
    private bool isGoingTooffice = false;
    private bool isGoingTofactory = false;
    private bool isGoingTowarehouse = false;
    private bool isCircling = true;
    public float angle = 0f;
    private float previousAngle = 0f;

    public int remainingLaps = 3; // 

    void Update()
    {
        if (isGoingTooffice)
        {
            Vector3 dir = (destinationoffice.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        if (isGoingTofactory)
        {
            Vector3 dir = (destinationfactory.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        if (isGoingTowarehouse)
        {
            Vector3 dir = (destinationwarehouse.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        else if (isCircling)
        {
            angle += speed * Time.deltaTime;
            float rad = angle * Mathf.Deg2Rad;

            float x = centerPoint.position.x + radius * Mathf.Cos(rad);
            float z = centerPoint.position.z + radius * Mathf.Sin(rad);
            transform.position = new Vector3(x, transform.position.y, z);

            Vector3 direction = new Vector3(-Mathf.Sin(rad), 0, Mathf.Cos(rad));
            transform.rotation = Quaternion.LookRotation(direction);

            if (angle - previousAngle >= 360f)
            {
                remainingLaps--;
                previousAngle = angle;

                Debug.Log($"{gameObject.name} finished a lap. Remaining: {remainingLaps}");

          
                if (remainingLaps <= 0)
                {
                    isCircling = false;
                    script.score -= 10;
                }
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("officegate"))
        {
            CapsuleClickActivator activator = other.GetComponent<CapsuleClickActivator>();
            if (activator != null && activator.IsActivated())
            {
                isGoingTooffice = true;
                isCircling = false;
            }
        }
        if (other.CompareTag("factorygate"))
        {
            CapsuleClickActivator activator = other.GetComponent<CapsuleClickActivator>();
            if (activator != null && activator.IsActivated())
            {
                isGoingTofactory = true;
                isCircling = false;
            }
        }
        if (other.CompareTag("warehousegate"))
        {
            CapsuleClickActivator activator = other.GetComponent<CapsuleClickActivator>();
            if (activator != null && activator.IsActivated())
            {
                isGoingTowarehouse = true;
                isCircling = false;
            }
        }
    }

}

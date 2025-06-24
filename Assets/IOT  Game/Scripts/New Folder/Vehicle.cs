using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class Vehicle : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    //public Transform centerPoint;
    public float radius = 5f;
    public float speed = 1f;
    public Scorenum script;
    public Transform destinationred;
    public Transform destinationoffice;
    public Transform destinationfactory;
    public Transform destinationwarehouse;
    private bool isGoingTooRed = false;
    private bool isGoingTooffice = false;
    private bool isGoingTofactory = false;
    private bool isGoingTowarehouse = false;

    
    public static int counter = 0;
    private bool hasFinished = false;
    public bool hasScored = false;


    // public bool panelShown = false;


    private bool isCircling = true;
    public float angle = 0f;
    

    public int remainingLaps = 3; 
    public TextMeshProUGUI laps;
    AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
        //AudioManager.instance.PlayMusic("IOT-BG");
    }
    void Update()
    {
        if (isGoingTooRed)
        {
            Vector3 dir = (destinationred.position - transform.position).normalized;

           /* if (dir.magnitude < 0.95f) // وصلت
            {
                audioManager.PlaySFX("Bonus");
                isGoingTooffice = false;
                Destroy(gameObject, 0.001f);
                counter++;
                Debug.Log("counter is " + counter);
                return;
            }*/

            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dir);
        }

        if (isGoingTooffice)
        {
            Vector3 dir = (destinationoffice.position - transform.position).normalized;

           /* if (dir.magnitude < 0.95f) // وصلت
            {
                audioManager.PlaySFX("Bonus");
                isGoingTooffice = false;
                Destroy(gameObject,0.001f);
                counter++;
                Debug.Log("counter is " + counter);
                return;
            }*/

            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        if (isGoingTofactory)
        {
            Vector3 dir = (destinationfactory.position - transform.position).normalized;

         /*   if (dir.magnitude < 0.95f) // وصلت
            {
                audioManager.PlaySFX("Bonus");
                isGoingTofactory = false;
                Destroy(gameObject, 0.001f);
                counter++;
                Debug.Log("counter is " + counter);
                return;
            }*/

            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        if (isGoingTowarehouse)
        {
            Vector3 dir = (destinationwarehouse.position - transform.position).normalized;

          /*  if (dir.magnitude < 0.95f) // وصلت
            {
                audioManager.PlaySFX("Bonus");

                isGoingTowarehouse = false;
                Destroy(gameObject, 0.001f);
                counter++;
                Debug.Log("counter is " + counter);
                return;
            }*/

            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        else if (isCircling)
        {
            if (waypoints.Length == 0) return;

           Transform targetPoint = waypoints[currentWaypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        Vector3 direction = targetPoint.position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }



            if (Vector3.Distance(transform.position, targetPoint.position) < 0.2f)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length)
                {
                    remainingLaps--;
                    currentWaypointIndex = 0;
       

                    Debug.Log($"{gameObject.name} finished a lap. Remaining: {remainingLaps}");
                    laps.text = remainingLaps.ToString();

                    if (remainingLaps <= 0 && !hasFinished)
                    {
                        hasFinished = true;
                        isCircling = false;
                        counter++;
                        audioManager.PlaySFX("Lose point");
                        Debug.Log("counter is " + counter);
                        script.score -= 10;
                        Destroy(gameObject, 0.001f);
                    }

                }
            }
        }

      //  wingame();

    }


  /*  public void wingame()
    {
        if (panelShown) return; // Prevent showing again

        if (script.score >= 40 && counter == 4)
        {
            winpanel.SetActive(true);
            panelShown = true;
        }
        else if (script.score < 40 && counter == 4)
        {
            losepanel.SetActive(true);
            panelShown = true;
        }
    }*/


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("redgate"))
        {
            CapsuleClickActivator activator = other.GetComponent<CapsuleClickActivator>();
            if (activator != null && activator.IsActivated())
            {
                isGoingTooRed = true;
                isCircling = false;
            }
        }

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

        if (other.CompareTag("red"))
        {
            if (!hasFinished)
            {
                audioManager.PlaySFX("Bonus");
                isGoingTooffice = false;
                hasFinished = true;
                counter++;
                Debug.Log("counter is " + counter);
                Destroy(gameObject, 0.001f);
            }
            return;
        }
        if (other.CompareTag("blue"))// office
        {
            if (!hasFinished)
            {
                audioManager.PlaySFX("Bonus");
                isGoingTooffice = false;
                hasFinished = true;
                counter++;
                Debug.Log("counter is " + counter);
                Destroy(gameObject, 0.001f);
            }
            return;
        }
        if (other.CompareTag("yellow"))
        {
            if (!hasFinished)
            {
                audioManager.PlaySFX("Bonus");
                isGoingTooffice = false;
                hasFinished = true;
                counter++;
                Debug.Log("counter is " + counter);
                Destroy(gameObject, 0.001f);
            }
            return;
        }
        if (other.CompareTag("green"))
        {
            if (!hasFinished)
            {
                audioManager.PlaySFX("Bonus");
                isGoingTooffice = false;
                hasFinished = true;
                counter++;
                Debug.Log("counter is " + counter);
                Destroy(gameObject, 0.001f);
            }
            return;
        }
    }


    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        if (!AudioManager.instance.GetComponent<AudioSource>().isPlaying)
        {
            AudioManager.instance.PlayMusic("IOT-BG");
        }
    }
    public void ToggleMusic()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
        }
    }


}

/*
[SerializeField] private Transform[] pathPoints;
[SerializeField] float speed = 2f;
[SerializeField] int maxLaps = 3;
[SerializeField] private float rotationSpeed = 2f;

[SerializeField] GameObject destination;
private int currentPointIndex = 0;
private int currentLaps=0;
//   private bool isActive = true;

public Transform destinationoffice;
public Transform destinationfactory;
public Transform destinationwarehouse;


private bool isGoingTooffice = false;
private bool isGoingTofactory = false;
private bool isGoingTowarehouse = false;
private bool isCircling = true;


void Update()
{
    if (isGoingTooffice)
    {
        Vector3 dir = (destinationoffice.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir);
    }
    else if (isGoingTofactory)
    {
        Vector3 dir = (destinationfactory.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir);
    }
    else if (isGoingTowarehouse)
    {
        Vector3 dir = (destinationwarehouse.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir);
    }
 else if (isCircling)
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
}




private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Gate"))
    {
        CapsuleClickActivator activator = other.GetComponent<CapsuleClickActivator>();
        if (activator != null && activator.IsActivated())
        {
            isGoingTooffice = true;
            isGoingTofactory = false;
            isGoingTowarehouse = false;
            isCircling = false;
        }
    }
    else if (other.CompareTag("factorygate"))
    {
        CapsuleClickActivator activator = other.GetComponent<CapsuleClickActivator>();
        if (activator != null && activator.IsActivated())
        {
            isGoingTooffice = false;
            isGoingTofactory = true;
            isGoingTowarehouse = false;
            isCircling = false;
        }
    }
    else if (other.CompareTag("warehousegate"))
    {
        CapsuleClickActivator activator = other.GetComponent<CapsuleClickActivator>();
        if (activator != null && activator.IsActivated())
        {
            isGoingTooffice = false;
            isGoingTofactory = false;
            isGoingTowarehouse = true;
            isCircling = false;
        }
    }











    //     if (!isActive) return;

    /* if (other.transform == destination)
     {


         Destroy(gameObject);
       //  GameControllerForGates.instance.AddScore(10);
     }
     else
     {
         isActive = false;
         Destroy(gameObject, 2f);
      //   GameControllerForGates.instance.AddScore(-5);
     }
     if (currentLaps >= maxLaps)

     {
         isActive = false;
     }
     else if (other.CompareTag("LapTrigger"))
     {
         currentLaps++;
         Debug.Log("Lap: " + currentLaps);



     }*/



/*
    }


}
*/
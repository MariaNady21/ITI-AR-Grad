using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject[] molePrefabs;
    [SerializeField] GameObject deadMolePrefab;
    [SerializeField] Transform[] spawnPoints;


    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverImage;
    [SerializeField] private GameObject winImage;
    [SerializeField] public GameObject explosionVFX;


    //private bool isSpawned = false;


    private int score = 0;
    private List<int> usedHoles = new List<int>();
   

    private Coroutine moleSpawnRoutine;
    AudioManager audioManager;
    void Awake()
    {
        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }
    void Start()
    {
        Debug.Log("GameManager is Active: " + gameObject.activeSelf);

        SpawnMole(); 
        SetSpawnPoints(spawnPoints); 
        usedHoles.Clear();
    }
        void Update()
    {
        //// في الـ Editor: نستخدم الماوس
        //if (Application.isEditor && Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //    HandleRaycast(ray);
        //}
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            HandleRaycast(ray);
        }

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Debug.Log("Touch detected!");
        }

       

    }

    void HandleRaycast(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("You hit: " + hit.collider.name);
            Mole mole = hit.collider.GetComponent<Mole>();
            if (mole != null)
            {
                audioManager.PlaySFX("Hit");
                Debug.Log("Mole was clicked!");
                mole.Kill();
            }
        }
        else
        {

            score = Mathf.Max(0, score - 1);
            scoreText.text = "Score: " + score;
        }

    }
    void SpawnMole()
    {
        

        if (usedHoles == null)
            usedHoles = new List<int>();

        if (usedHoles.Count >= spawnPoints.Length)
            return;

        int index;
        do
        {
            index = Random.Range(0, spawnPoints.Length);
        } while (usedHoles.Contains(index));

        Transform hole = spawnPoints[index];

        int randomMole = Random.Range(0, molePrefabs.Length);

        
        GameObject mole = Instantiate(molePrefabs[randomMole], hole);
        mole.transform.localPosition = Vector3.zero;
        mole.transform.localRotation = Quaternion.identity;

        mole.GetComponent<Mole>().Init(this, index);
    }

    public void SetSpawnPoints(Transform[] points)
    {
        spawnPoints = points;
        usedHoles.Clear();

        if (moleSpawnRoutine != null)
            StopCoroutine(moleSpawnRoutine);

        moleSpawnRoutine = StartCoroutine(SpawnMolesLoop());
    }

    public void IncreaseScore(int holeIndex, Vector3 deadMolePosition)
    {

        score++;
        scoreText.text = "Score: " + score;

        usedHoles.Add(holeIndex);

        GameObject deadMole = Instantiate(deadMolePrefab, deadMolePosition, Quaternion.identity, spawnPoints[holeIndex]);
        Destroy(deadMole, 2f); 
        usedHoles.Add(holeIndex);
        StartCoroutine(ReleaseHoleAfterDelay(holeIndex, 2f));

        if (score >= 30) 
        {
            PlayerWin();
        }
    }


    IEnumerator ReleaseHoleAfterDelay(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        usedHoles.Remove(index);
    }

    IEnumerator SpawnMolesLoop()
    {
        while (true)
        {
            SpawnMole();

            float spawnInterval = Mathf.Lerp(2f, 0.5f, score / 20f); // كل ما السكور زاد، يظهر أسرع
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void PlayerWin()
    {
        Debug.Log("You Win!");
        audioManager.PlaySFX("Win");
        audioManager.StopMusic();

        StopAllCoroutines();
        CancelInvoke();

        winImage.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    public void PlayerLose()
    {
        Debug.Log("You clicked on a bomb! You lose.");
        audioManager.PlaySFX("Lose");
        audioManager.StopMusic();



        CancelInvoke(nameof(SpawnMole));
        StopAllCoroutines();

        
        foreach (var mole in GameObject.FindGameObjectsWithTag("Mole"))
        {
            Destroy(mole);
        }

        gameOverImage.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        AudioManager.instance.PlayMusic("BackGround");
    }




}

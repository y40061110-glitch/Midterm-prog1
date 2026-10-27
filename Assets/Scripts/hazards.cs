using UnityEngine;
using TMPro;

public class hazards : MonoBehaviour
{
    public PlayerScript player; 
    public Rigidbody2D hazard1;
    public Rigidbody2D hazard2;     
    public Rigidbody2D hazard3;
    public Rigidbody2D hazard4;
    public Rigidbody2D hazard5;
    public TMP_Text stageText;

    public float speed = 1.5f;

    public float changeDirectionTime = 1.5f;
    public float safeDistance = 2f;
    private Vector2 direction1;
    private Vector2 direction2;
    private Vector2 direction3;
    private Vector2 direction4;
    private Vector2 direction5;

    private float directionTimer;
    private bool stageTwoStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stageText.text = "Stage 1";

        hazard1.gameObject.SetActive(true);
        hazard2.gameObject.SetActive(false);
        hazard3.gameObject.SetActive(false);
        hazard4.gameObject.SetActive(false);
        hazard5.gameObject.SetActive(false);
    
       chooseNewDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        return;
        int score = player.Score;

        if (score >= 2 && !hazard2.gameObject.activeSelf)
        { float distance = Vector2.Distance(player.transform.position, hazard2.transform.position);
            if (distance > safeDistance)
            hazard2.gameObject.SetActive(true);
        }

        if (score >= 4 && !hazard3.gameObject.activeSelf)
        { float distance = Vector2.Distance(player.transform.position, hazard3.transform.position);
            if (distance > safeDistance)
            hazard3.gameObject.SetActive(true);
        }
        
        if (score >= 6 && !hazard4.gameObject.activeSelf)
        { float distance = Vector2.Distance(player.transform.position, hazard4.transform.position);
            if (distance > safeDistance)
            hazard4.gameObject.SetActive(true);
        }
        
        if (score >= 8 && !hazard5.gameObject.activeSelf)
        { float distance = Vector2.Distance(player.transform.position, hazard5.transform.position);
            if (distance > safeDistance)
            hazard5.gameObject.SetActive(true);
        }

        if (score >= 10 && !stageTwoStarted)
        
        { stageText.text = "Stage Two";
            stageTwoStarted = true;
        }
        
        directionTimer -= Time.deltaTime;

        if (directionTimer <= 0f)
        chooseNewDirection();
    }

    void FixedUpdate()
    { 
        float moveSpeed = speed;

        if (player.Score >= 10)
        moveSpeed *= 3f;

        hazard1.linearVelocity = direction1 * moveSpeed;

        if (hazard2.gameObject.activeSelf)
            hazard2.linearVelocity = direction2 * moveSpeed;

        if (hazard3.gameObject.activeSelf)
            hazard3.linearVelocity = direction3 * moveSpeed;

        if (hazard4.gameObject.activeSelf)
            hazard4.linearVelocity = direction4 * moveSpeed;

        if (hazard5.gameObject.activeSelf)
            hazard5.linearVelocity = direction5 * moveSpeed;

}

    void chooseNewDirection()
    {
        direction1 = Random.insideUnitCircle.normalized;
        direction2 = Random.insideUnitCircle.normalized;
        direction3 = Random.insideUnitCircle.normalized;
        direction4 = Random.insideUnitCircle.normalized;
        direction5 = Random.insideUnitCircle.normalized;

        directionTimer = changeDirectionTime;
    }
}
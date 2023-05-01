using UnityEngine;

public class IMove : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float maxHeight = 10f;
    [SerializeField] float minHeight = 1f;
    [SerializeField] float pauseTime = 1f;
    [SerializeField] bool debugMode = false;

    [SerializeField] float startDelay = 0f;

    [SerializeField] Vector3 movementDirection = Vector3.up;
    [SerializeField] bool isOn = true;

    AudioPlayer audioPlayer;

    [SerializeField] bool goingUp = true;
    bool isPaused = false;

    float timePaused = 0f;
    float timeUntilStart = 0f;

    void Start() 
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        if(!isOn) return;
        if(startDelay > 0f && timeUntilStart <= startDelay)
        {
            timeUntilStart += Time.deltaTime;
            return;
        }
        
        checkDirection();
        checkPause();
        if(!isPaused)
        {
            audioPlayer.play();
            move();
        }
        else
        {
            audioPlayer.stop();
        }

        if(debugMode)
        {
            Debug.Log("Paused " + isPaused);
            Debug.Log("Time paused " + timePaused);
            Debug.Log("Going up " + goingUp);
        }
    }

    void checkDirection()
    {
        if (goingUp && transform.position.y >= maxHeight)
        {
            goingUp = false;
        }
        else if (!goingUp && transform.position.y <= minHeight)
        {
            goingUp = true;
        } 
    }

    void checkPause()
    {
        if (transform.position.y >= maxHeight && timePaused < pauseTime)
        {
            timePaused += Time.deltaTime;
            isPaused = true;
        }
        else if (transform.position.y <= minHeight && timePaused < pauseTime)
        {
            timePaused += Time.deltaTime;
            isPaused = true;
        }
        else if (timePaused >= pauseTime)
        {
            timePaused = 0f;
            isPaused = false;
        }
    }

    void move()
    {
        if (goingUp)
        {
            transform.Translate(movementDirection * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-movementDirection * speed * Time.deltaTime);
        }
    }

    public void TurnOn()
    {
        isOn = true;
    }
}

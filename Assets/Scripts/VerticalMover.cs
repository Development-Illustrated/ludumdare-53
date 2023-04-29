using UnityEngine;

public class VerticalMover : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float maxHeight = 10f;
    [SerializeField] float minHeight = 1f;
    [SerializeField] float pauseTime = 1f;
    [SerializeField] bool debugMode = false;

    bool goingUp = true;
    bool isPaused = false;

    float timePaused = 0f;

    void Update()
    {
        checkDirection();
        checkPause();
        if(!isPaused)
        {
            move();
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
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}

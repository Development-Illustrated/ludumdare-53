using UnityEngine;

public class VerticalMover : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float maxHeight = 10f;
    [SerializeField] float minHeight = 1f;
    [SerializeField] float pauseTime = 1f;
    [SerializeField] bool debugMode = false;

    [SerializeField] Vector3 movementDirection = Vector3.up;

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
            transform.Translate(movementDirection * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-movementDirection * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}

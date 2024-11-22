using UnityEngine;

public class MovingPipe : MonoBehaviour
{
    private float pipeSpeed;
    public float PipeSpeed
    {
        set { pipeSpeed = value; }
    }

    private Transform endPipePosition;
    public Transform EndPipePosition
    {
        set { endPipePosition = value; }
    }

    private void MovePipe()
    {
        transform.position += Vector3.left * pipeSpeed * Time.fixedDeltaTime;
        if (transform.position.x <= endPipePosition.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        MovePipe();
    }
}

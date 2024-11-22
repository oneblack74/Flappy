using System.Collections;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private Transform startPipePosition;
    [SerializeField] private Transform endPipePosition;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float pipeDelay;
    [SerializeField] private float pipeSpeed;
    [SerializeField] private Transform pipeParent;



    private IEnumerator PipeSpawner()
    {
        while (true)
        {
            CreatePipe();
            yield return new WaitForSeconds(pipeDelay);
        }
    }

    private void CreatePipe()
    {
        Vector3 position = startPipePosition.position + new Vector3(0, RandomYPosition(), 0);
        GameObject pipe = Instantiate(pipePrefab, position, Quaternion.identity, pipeParent);
        MovingPipe movingPipe = pipe.GetComponent<MovingPipe>();
        movingPipe.EndPipePosition = endPipePosition;
        movingPipe.PipeSpeed = pipeSpeed;
    }

    private float RandomYPosition()
    {
        return Random.Range(-1.8f, 1.8f);
    }


    public void GameOver()
    {
        StopAllCoroutines();
        foreach (Transform child in pipeParent)
        {
            child.GetComponent<MovingPipe>().enabled = false;
        }
    }

    public void StartPipeManager()
    {
        StartCoroutine(PipeSpawner());
    }

    public void RestartPipeManager()
    {
        foreach (Transform child in pipeParent)
        {
            Destroy(child.gameObject);
        }
    }
}

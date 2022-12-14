using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ground
{
    Ground,
    Sky,
}

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private Ground ground = Ground.Ground;
    [SerializeField] private EcologistEnum ecologistEnum;
    private MovePoint movePoint = null;
    private Vector3 MyTransform = Vector3.zero;
    private Vector3 goalTransform = Vector3.zero;
    private Vector3 size = Vector3.zero;

    public EcologistEnum EcologistEnum { get { return ecologistEnum; } }

    void Start()
    {
        movePoint = FindObjectOfType<MovePoint>();
        MyTransform = this.transform.position;
        size = this.transform.localScale;
        if (ground == Ground.Ground)
        {
            if (movePoint.Groundpoints.Count > 0) goalTransform = movePoint.Groundpoints[Random.Range(0, movePoint.Groundpoints.Count)].position;
        }
        if(ground == Ground.Sky)
        {
            if (movePoint.Skypoints.Count > 0) goalTransform = movePoint.Skypoints[Random.Range(0, movePoint.Skypoints.Count)].position;
        }
    }

    private void OnEnable()
    {
        if (ground == Ground.Ground)
        {
            if (movePoint.Groundpoints.Count > 0) goalTransform = movePoint.Groundpoints[Random.Range(0, movePoint.Groundpoints.Count)].position;
        }
        if (ground == Ground.Sky)
        {
            if (movePoint.Skypoints.Count > 0) goalTransform = movePoint.Skypoints[Random.Range(0, movePoint.Skypoints.Count)].position;
        }
    }
    private void OnDisable()
    {
        Reset();
    }

    public void Reset()
    {
        this.transform.position = MyTransform;
        this.transform.localScale = size;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(this.transform.position, goalTransform) > 0.1f)
            transform.position = Vector3.MoveTowards(transform.position, goalTransform, speed * 0.01f);
        else
        {
            if (ground == Ground.Ground)
            {
                if (movePoint.Groundpoints.Count > 0) goalTransform = movePoint.Groundpoints[Random.Range(0, movePoint.Groundpoints.Count)].position;
            }
            if (ground == Ground.Sky)
            {
                if (movePoint.Skypoints.Count > 0) goalTransform = movePoint.Skypoints[Random.Range(0, movePoint.Skypoints.Count)].position;
            }

        }
        Vector3 dir = goalTransform - this.transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 5f);
    }
}

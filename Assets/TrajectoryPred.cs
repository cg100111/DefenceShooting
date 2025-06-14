using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TrajectoryPred : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int steps = 30;
    [SerializeField] float timeStep = 0.1f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] private GameObject shot1Prefab;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTrajectory(Vector3 startPos, Vector3 velocity)
    {
        float mass = shot1Prefab.GetComponent<Rigidbody2D>().mass;
        float adjustedGravity = gravity * mass;
        Vector3[] points = new Vector3[steps];
        for (int i = 0; i < steps; i++)
        {
            float t = i * timeStep;
            Vector3 pos = startPos + velocity * t;
            pos.y += 0.5f * adjustedGravity * t * t;
            points[i] = pos;
        }
        lineRenderer.positionCount = steps;
        lineRenderer.SetPositions(points);
    }

    public void Hide()
    {
        lineRenderer.positionCount = 0;
    }
}

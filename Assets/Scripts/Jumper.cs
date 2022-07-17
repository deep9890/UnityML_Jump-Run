using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Jumper : Agent
{
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode jumpKey;
    
    private bool hopIsready = true;
    private Rigidbody rBody;
    private Vector3 startingPosition;
    private int score = 0;
    
    public event Action OnReset;
    
    public override void Initialize()
    {
        rBody = GetComponent<Rigidbody>();
        startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if(hopIsready)
            RequestDecision();
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if (Mathf.FloorToInt(vectorAction[0]) == 1)
            Hop();
    }

    public override void OnEpisodeBegin()
    {
        Reset();
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        
        if (Input.GetKey(jumpKey))
            actionsOut[0] = 1;
    }

    private void Hop()
    {
        if (hopIsready)
        {
            rBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
            hopIsready = false;
        }
    }
    
    private void Reset()
    {
        score = 0;
        hopIsready = true;
        
        //Reset Movement and Position
        transform.position = startingPosition;
        rBody.velocity = Vector3.zero;
        
        OnReset?.Invoke();
    }

    private void OnCollisionEnter(Collision collidedObj)
    {
        if (collidedObj.gameObject.CompareTag("Street"))
            hopIsready = true;
        
        else if (collidedObj.gameObject.CompareTag("Mover") || collidedObj.gameObject.CompareTag("DoubleMover") ||  collidedObj.gameObject.CompareTag("wallObs") ||
        collidedObj.gameObject.CompareTag("ballObs"))
        {
            AddReward(-1.0f);
            score = 0;
            ScoreCollector.Instance.AddScore(score);
            EndEpisode();
        }
    }

    private void OnTriggerEnter(Collider collidedObj)
    {
        if (collidedObj.gameObject.CompareTag("score"))
        {
            
            AddReward(0.1f);
            score+=1;
            ScoreCollector.Instance.AddScore(score);
        }
        else if(collidedObj.gameObject.CompareTag("silver"))
        {
            AddReward(0.5f);
            score += 2;
            ScoreCollector.Instance.AddScore(score);
            Destroy(collidedObj.gameObject);
        }else if(collidedObj.gameObject.CompareTag("gold"))
        {
            AddReward(1.0f);
            score+=3;
            ScoreCollector.Instance.AddScore(score);
            Destroy(collidedObj.gameObject);
        };
    }
}

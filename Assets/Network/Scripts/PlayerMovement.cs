using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private float MoveSpeed;
    
    void Start()
    {
        
    }

    // Check any Input.
    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        // Can Access to our data
        if(GetInput<PlayerInputData>(out var inputData))
        {
            transform.Translate(inputData.Direction*MoveSpeed*Runner.DeltaTime);
        }
    }

    void Update()
    {

    }
}

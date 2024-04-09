using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField]
    private InputActionReference _moveInput;

    // Move Input È°¼ºÈ­
    private void OnEnable()
    {
        _moveInput.action.Enable();
    }

    private void OnDisable()
    {
        _moveInput.action?.Disable();
    }

    void Start()
    {
        //access Network Runner
        NetworkManager.Instance.SessionRunner.AddCallbacks(this);
        
    }

    void Update()
    {
        

    }

    #region RunnerCallbacks
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Vector2 direction = _moveInput.action.ReadValue<Vector2>();
        Vector3 dir = new Vector3(direction.x, 0, direction.y);

        PlayerInputData inputData = new PlayerInputData();

        // Moving Test
        inputData.Direction = dir;

        // Send input property to Network
        input.Set(inputData);
    }
    #endregion

    #region UnusedRunnerCallbacks
    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }


    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }
    #endregion
}
public struct PlayerInputData : INetworkInput
{
    public Vector3 Direction;
}
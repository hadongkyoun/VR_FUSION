using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System.Threading.Tasks;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks

{



    

    // ���α׷� ���� ��Ʈ��ũ�� �����ϰ� �����ϴ� ����� �ϳ��� Network Manager �ν��Ͻ��� ���� ����
    // �̱��� ����
    // Makes it easy to access the NetworkManager and its methods from anywhere in the game.



    #region ����
    public static NetworkManager Instance { get; private set; }
    public NetworkRunner SessionRunner { get; private set; }

    [SerializeField]
    private GameObject _runnerPrefab;
    #endregion


    //Network Manager Singleton
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }



    public async void StartSharedSession()
    {
        //Create Runner
        CreateRunner();
        //Load Scene
        await LoadScene();
        //ConnectSession
        await Connect();
    }
    public async Task LoadScene()
    {
       AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            await Task.Yield();
        }
    }

    public void CreateRunner()
    {
        SessionRunner = Instantiate(_runnerPrefab, transform).GetComponent<NetworkRunner>();

        SessionRunner.AddCallbacks(this);
    }

    private async Task Connect()
    {
        var args = new StartGameArgs()
        {

            GameMode = GameMode.Shared,
            SessionName = "TestSesstion",
            SceneManager = GetComponent<NetworkSceneManagerDefault>(),
            
        };

        var result = await SessionRunner.StartGame(args);

        if(result.Ok)
        {
            Debug.Log("StartGame Successful!");
        }
        else
        {
            Debug.LogError(result.ErrorMessage);
        }
    }

    private void Start()
    {

        //StartSharedSession();
    }

    void Update()
    {
        
    }

    // �� ����
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("A new Player joined to the session");
    }

    // �� ������
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }
    // �������� �˴ٿ�
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("Runner Shutdown");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
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
}

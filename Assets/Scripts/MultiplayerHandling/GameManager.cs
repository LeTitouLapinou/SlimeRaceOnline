using System;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    
    public static GameManager Instance { get; private set; } //Define GameManager as a Singleton

    public event Action<GameState> OnGameStateChangedEvent;
    public event Action<float> OnColorSelectionTimerChangedEvent;

    [SerializeField] private NetworkVariable<GameState> currentGameState = new NetworkVariable<GameState>();
    [SerializeField] private float colorSelectionTimerInit;

    private NetworkVariable<float> colorSelectionTimer = new NetworkVariable<float>(0f, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    public NetworkVariable<float> ColorSelectionTimer => colorSelectionTimer; //Expose the variable safely without allowing other scripts to write it (read-only)


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one GameManager instance!");
        }
        Instance = this;
    }

    public override void OnNetworkSpawn()
    {
        if (IsClient)
        {
            currentGameState.OnValueChanged += OnGameStateChanged; //Subscribe to the value change of the NetworkVariable currentGameState. OnValueChanged is native to Unity and passes two parameters: the previous value and the new value
            colorSelectionTimer.OnValueChanged += OnColorSelectionTimerChanged;
        }
    }


    private void Update()
    {
        if (!IsServer) return; //Stop the update if IsClient

        #region Decrement color selection timer

        if (currentGameState.Value == GameState.ChoosingColorRound)
        {
            if (colorSelectionTimer.Value > 0f)
            {
                colorSelectionTimer.Value -= Time.deltaTime; //decrement timer

                Debug.Log(colorSelectionTimer.Value);

                if (colorSelectionTimer.Value <= 0f)
                {
                    colorSelectionTimer.Value = 0f;
                    ChangeGameState(GameState.ColorResolution); //Change state
                }
            }

        }
        #endregion
    }

    public void ChangeGameState(GameState newGameState)
    {
        if (IsServer)
        {
            currentGameState.Value = newGameState; //Changes the GameState on the server

            if (newGameState == GameState.ChoosingColorRound)
            {
                colorSelectionTimer.Value = colorSelectionTimerInit;
            }
        }

        if (IsClient)
        {
            Debug.Log($"New game state is: {newGameState}");
        }
    }




    private void OnGameStateChanged(GameState previousGameState, GameState newGameState) //When the GameState is changed, only clients execute those functions
    {
        Debug.Log($"Game state changed from {previousGameState} to {newGameState}");

        OnGameStateChangedEvent?.Invoke(newGameState); //Trigger the event for everyone subscribed to it

        if (newGameState == GameState.ChoosingColorRound)
        {
            //Color chosing logic 
        }

        if (newGameState == GameState.ColorResolution)
        {
            //Color resolution logic
        }
    }

    private void OnColorSelectionTimerChanged(float oldValue, float newValue)
    {
        OnColorSelectionTimerChangedEvent?.Invoke(newValue);
    }

}

public interface AiState
{
    AiStateID GetID();
     void Enter(AiAgent agent);
    void Update();
    void Exit();
}

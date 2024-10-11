
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class DyingState : State
    {
        // constructor
        public DyingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.CheckForIdle();
            player.CheckForRun();
            player.CheckForCrouch();
            player.CheckForJump();
            Debug.Log("checking for death");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
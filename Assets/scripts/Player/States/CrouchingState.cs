
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class CrouchingState : State
    {
        // constructor
        public CrouchingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("arthur_crouch", 0, 0);
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
            player.CheckForDeath();
            Debug.Log("checking for crouch");

            if (Input.GetKeyUp(KeyCode.C))
            {
                sm.ChangeState(player.idleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
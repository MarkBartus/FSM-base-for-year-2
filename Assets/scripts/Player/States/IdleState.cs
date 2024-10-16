
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {

        private float _horizontalInput;
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _horizontalInput = 0f;

            player.anim.Play("arthur_stand", 0, 0);
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
            player.CheckForRun();
            player.CheckForDeath();
            player.CheckForCrouch();
            player.CheckForJump();
            Debug.Log("checking for run");
            base.LogicUpdate();

            _horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            {
                sm.ChangeState(player.runningState);
            }
               
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

    }
}
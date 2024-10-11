
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {

        private float _horizontalInput;



        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {

        }

        public override void Enter()
        {
            base.Enter();           
            _horizontalInput = 0f;
            player.anim.Play("arthur_run", 0, 0);
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

            if (Input.GetKey(KeyCode.A))
            {
               player.sr.flipX = true;
            }
            else if(Input.GetKey(KeyCode.D))
            {
                player.sr.flipX = false;
            }

            player.CheckForIdle();
            player.CheckForDeath();
            player.CheckForCrouch();
            player.CheckForJump();
            Debug.Log("checking for idle");

            

            _horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            {
                sm.ChangeState(player.idleState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Vector2 vel = player.rb.velocity;
            vel.x = _horizontalInput * player.speed;
            player.rb.velocity = vel;
        }
    }
}
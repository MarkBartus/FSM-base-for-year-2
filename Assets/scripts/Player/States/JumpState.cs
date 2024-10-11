
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class JumpState : State
    {


        // constructor
        public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Vector2 vel = player.rb.velocity;
            vel.y = 0;
            player.rb.velocity = vel;
            player.rb.AddForce(player.rb.transform.up * player.jumpForce * 10 , ForceMode2D.Impulse);
            player.anim.Play("arthur_jump_up", 0, 0);
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
            if(player.groundCheck == true)
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
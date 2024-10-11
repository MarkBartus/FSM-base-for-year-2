using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Animator anim;
        public SpriteRenderer sr;

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public DyingState dyingState;
        public CrouchingState crouchingState;
        public JumpState jumpState;

        public StateMachine sm;

        public float speed = 6f;
        public float jumpForce = 4f;

        public bool groundCheck;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            dyingState = new DyingState(this, sm);
            crouchingState = new CrouchingState(this, sm);
            jumpState = new JumpState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press I for idle / a or d for run / q for death / c for crouch");

        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        public void CheckForJump()
        {

            if (groundCheck = true && Input.GetKey(KeyCode.Space))
            {
        
                sm.ChangeState(jumpState);
                groundCheck = false;
                return;
           
            }


        }


        public void CheckForRun()
        {
            if (Input.GetKey("a") || Input.GetKey("d")) // key held down
            {
                sm.ChangeState(runningState);
                return;
            }

        }


        public void CheckForIdle()
        {
            if (Input.GetKey("i") ) // key held down
            {
                sm.ChangeState(idleState);
            }

        }
        public void CheckForDeath()
        {
            if (Input.GetKey("q")) // key held down
            {
                sm.ChangeState(dyingState);
            }

        }
        public void CheckForCrouch()
        {
            if (Input.GetKey("c")) // key held down
            {
                sm.ChangeState(crouchingState);
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if(collision.gameObject.tag == "ground")
            {               
                groundCheck = true;
            }
        }

    }

}
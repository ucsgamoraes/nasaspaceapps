using UnityEngine;
using System.Collections;
using static UnityEditor.SceneView;

namespace AstronautPlayer
{

    public class AstronautPlayer : MonoBehaviour
    {

        private Animator anim;
        public CharacterController Controller;
        public float Speed = 600.0f;
        public float turnSpeed = 25.0f;
        public float jumpSpeed = 25.0f;
        private Vector3 moveDirection = Vector3.zero;
        public Transform Cam;
        private float vVelocity = 0.0f;
        public float gravity = 0.0f;

        void Start()
        {
            Controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void StartDialog ()
        {
            return;
        }

        void Update()
        {
            float Horizontal = Input.GetAxis("Horizontal") * Speed;
            float Vertical = Input.GetAxis("Vertical") * Speed;

            Vector3 camRight = new Vector3(Cam.transform.right.x, 0, Cam.transform.right.z).normalized;
            Vector3 camForward = new Vector3(Cam.transform.forward.x, 0, Cam.transform.forward.z).normalized;
            Vector3 Movement = camRight * Horizontal + camForward * Vertical;

            anim.SetBool("isGrounded", Controller.isGrounded);


            vVelocity -= gravity * Time.deltaTime;
            if (Controller.isGrounded)
            {
                vVelocity = 0;

                if (Input.GetAxis("Jump") > 0.1f)
                {
                    vVelocity = jumpSpeed;
                    anim.SetTrigger("Jump");
                }
            }


            if (Movement.magnitude != 0f)
            {
                anim.SetInteger("AnimationPar", 1);

                transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 1 * Time.deltaTime);

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, Movement, turnSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
            else
            {
                anim.SetInteger("AnimationPar", 0);
            }

            Movement.y = vVelocity;

            Controller.Move(Movement * Time.deltaTime);
        }
    }
}
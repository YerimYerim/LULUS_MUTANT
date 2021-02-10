using UnityEditor;
using UnityEngine;

namespace Assets.Yerim.Script
{
    public class PlayerControllerInput : MonoBehaviour
    {
        [SerializeField]private float MoveSpeed;

        [SerializeField] private float jumpPower;
        [SerializeField] private Rigidbody rigidbody;

        [SerializeField] private bool isJump = false;
        [SerializeField] private bool isGround = true;

        [SerializeField] private Transform playerTransform;
        // Update is called once per frame
        void Update()
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            
            Vector3 Position = transform.position;
            Position.x += Horizontal * Time.deltaTime * MoveSpeed;
            Position.z += Vertical * Time.deltaTime * MoveSpeed;
            transform.position = Position;

            if (isJump && isGround)
            {
                rigidbody.AddForce(Vector3.up * jumpPower);
                isJump = false;
                isGround = false;
            }
            else if(isJump == false && isGround)
            {
                isJump = Input.GetKeyDown(KeyCode.Space);
            }

            RaycastHit hit;
            Debug.DrawRay(playerTransform.position,playerTransform.up, Color.blue);
            print(isGround);
            if(Physics.Raycast(playerTransform.position, Vector3.down, out hit, 0.05f))
            {
                if (hit.transform.CompareTag("GROUND"))
                {
                    isGround = true;
                }

            }
            else
            {
                isGround = false;
            }
        }
    }
}

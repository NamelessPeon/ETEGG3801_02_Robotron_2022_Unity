using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_script : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject bullet_prefab;
    
    Vector2 move_input;
    Rigidbody[] my_rigid_body;

    public float health = 100;
    public float gravity;
    Transform mesh_transform;
    Transform aim_transform;

    //For Pausing
    public PauseMenu pMenu;

    // Used for doing raycast for mouse aim
    Ray mouse_aim_ray;
    bool aim_needs_recalculated = false;
    Camera main_camera;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello");
        my_rigid_body = GetComponents<Rigidbody>();
        mesh_transform = transform.Find("Player_mesh");

        aim_transform = mesh_transform.Find("aim_pt");
        //my_rigid_body.Length;

        main_camera = transform.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 vel = new Vector3(move_input.x, gravity, move_input.y) * speed;
        //transform.Translate(vel * Time.deltaTime, Space.World);
        my_rigid_body[0].velocity = vel;
        //my_rigid_body[0].AddForce(vel);
        if (aim_needs_recalculated)
        {
            // Turn off aiming until mouse moves again
            aim_needs_recalculated = false;
            // Do actual raycast
            RaycastHit hit_result;
            string[] my_layers = { "Ground" };
            if (Physics.Raycast(mouse_aim_ray, out hit_result, Mathf.Infinity, LayerMask.GetMask(my_layers) /*1 << 9*/))
            {
                Vector3 aim_pt = new Vector3(hit_result.point.x, mesh_transform.position.y, hit_result.point.z);
                mesh_transform.LookAt(aim_pt, Vector3.up);
            }

        }
    }
    public void fire(InputAction.CallbackContext context)
    {
        //if (!pMenu.checkPaused())
        {
            float value = context.ReadValue<float>();
            if (value > 0.5f && context.performed)
            {
                print("fire: " + value);
                GameObject new_inst = GameObject.Instantiate(bullet_prefab);
                new_inst.transform.position = aim_transform.position;
                new_inst.transform.rotation = aim_transform.rotation;

                //new_inst.transform.Rotate(Vector3.up, 90);
            }
        }
    }
    public void move(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();
        

    }

    public void look_at(InputAction.CallbackContext context)
    {
        Vector2 mouse_offset = context.ReadValue<Vector2>();
        PlayerInput input_comp = GetComponent<PlayerInput>();
        if (input_comp.currentControlScheme == "Keyboard&Mouse")
        {
            Vector2 mouse_pos = Mouse.current.position.ReadValue();
            aim_needs_recalculated = true;
            mouse_aim_ray = main_camera.ScreenPointToRay(mouse_pos);
            //print("mouse_offset " + mouse_offset);
            // print("Mouse_pos" + mouse_pos);
        }
        
        //TODO gamepad controls
    }
}


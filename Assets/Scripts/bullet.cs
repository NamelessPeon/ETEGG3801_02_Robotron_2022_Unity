using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            print("ignoring player");
            player_script player_script_ref = other.gameObject.GetComponent<player_script>();
            player_script_ref.health -= 10;
        }
        else
        {
            GameObject ui_game_object = GameObject.Find("Main_ui"); // SLOW! USE SPARINGLY
            main_ui_script ui_script = ui_game_object.GetComponent<main_ui_script>();
            ui_script.change_ui_score(42);

            print("I hit: " + other.gameObject.name);
            GameObject.Destroy(gameObject, 1.0f);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
    float state_timer = 2.0f;
    bool playing_walk = false;

    Animator anim_comp;

    // Start is called before the first frame update
    void Start()
    {
        anim_comp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        state_timer -= Time.deltaTime;
        if (state_timer <= 0)
        {
            state_timer = 2.0f;
            playing_walk = !playing_walk;
            anim_comp.SetBool("do_walk", playing_walk);
        }
    }
}

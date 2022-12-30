using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner_script : MonoBehaviour
{
    /*
    public GameObject enemy_prefab;
    public float health;
    public float distance_from_spawner;
    public float spawn_delay;
    public float spawn_timer;
    public int spawn_number;
    public float distance_from_spawn;
    public int total_spawn;
    */
    public GameObject enemy_prefab;
    int xPosition;
    int zPosition;
    int enemyCount;
    public int enemyTotal;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(EnemyDrop());
        EnemyDrop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyDrop()
    {
        while (enemyCount < enemyTotal)
        {
            xPosition = Random.Range(-3, 3);
            zPosition = Random.Range(-3, 3);
            Instantiate(enemy_prefab, new Vector3(transform.position.x + xPosition, transform.position.y, transform.position.z + zPosition), Quaternion.identity);
            //WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
    void enemy_spawn()
    {
    /*
        if (total_spawn != 0)
        {
            var spawned = 0;

            float random_angel = Random.Range(0, 360);

            float angel = random_angel;

            while (spawned != spawn_number)
            {
                float enemy_x = distance_from_spawner * cos(angel) //# cos in radians
				float enemy_y = distance_from_spawner * sin(angel) //# cos in radians


                Instantiate(enemy_prefab, new Vector3(distance_from_spawner * cos(angel), 1, ))


                self.add_child(enemy_inst)

                enemy_inst.transform.origin = transform.origin + Vector3(enemy_x, 0, enemy_y)


                angel += deg2rad(distance_arround_spawner)

                spawned += 1

                total_spawn -= 1
    
            }
        }
    */
    }
}
/*spawn_timer -= delta
	if spawn_timer <= 0:
		if total_spawn != 0:
			var spawned = 0
			spawn_timer += spawn_delay
			var random_angel = randi()%361
			var angel = random_angel
			while (spawned != spawn_number):
			
				var enemy_inst = enemy_scene.instance()
		
				var enemy_x  = distance_from_spawner * cos(angel) # cos in radians
				var enemy_y  = distance_from_spawner * sin(angel) # cos in radians
		
			
				self.add_child(enemy_inst)
				enemy_inst.transform.origin = transform.origin + Vector3(enemy_x, 0, enemy_y)
			
				angel += deg2rad(distance_arround_spawner)
				spawned += 1
				total_spawn -= 1
	*/
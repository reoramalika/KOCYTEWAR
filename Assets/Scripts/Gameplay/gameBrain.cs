using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBrain : MonoBehaviour {
    GameObject prefab, go;
    public float routinTime,currentTime;
    private bool stat;
    enemy enemy;
    private int score = 0;
    public GUIText textScore;

    private List<GameObject> enemies;
    private List<float> enemySpeed;
    Material m;

    /*public SpriteRenderer bodyArea;
    private Material spriteDefault,temp;*/

    // Use this for initialization
    void Start ()
    {
        /*spriteDefault = bodyArea.material;
        bodyArea.material = new Material(Shader.Find("Diffuse"));
        temp = bodyArea.material;*/

        enemies = new List<GameObject>();
        enemySpeed = new List<float>();
        Debug.Log("inserting enemies");
        enemies.Add(Resources.Load("High Bactery") as GameObject);
        enemySpeed.Add(0.1f);
        enemies.Add(Resources.Load("Middle Bactery") as GameObject);
        enemySpeed.Add(0.1f);
        enemies.Add(Resources.Load("Low Bactery") as GameObject);
        enemySpeed.Add(0.1f);
        Debug.Log(enemies.Count+" enemies inserted");
    }
	
	// Update is called once per frame
	void Update () {
        if (!stat)
        {
            stat = true;
            StartCoroutine(spawnEnemy(Random.Range(0,enemies.Count),1f));
        }
    }

    IEnumerator spawnEnemy(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        enemy = (enemy)enemies[index].GetComponent("enemy");
        enemy.moveSpeed = enemySpeed[index];
        Debug.Log("speed" + enemy.moveSpeed);

        go =Instantiate(enemies[index]);
        go.transform.position = new Vector2(Random.Range(6.6f, -6.6f),3);
        stat=false;
    }

    public void onDamage()
    {
        //bodyArea.material = new Material( spriteDefault);
        //bodyArea.material.Lerp(temp, new Material(spriteDefault), Mathf.PingPong(Time.time,2.0f)/2.0f);
    }

    public void addScore(int value)
    {
        score += value;
        updateScore();
    }

    private void updateScore()
    {
        textScore.text = "Score " + score;
    }
}

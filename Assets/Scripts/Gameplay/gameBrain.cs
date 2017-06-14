using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBrain : MonoBehaviour {
    GameObject imuneObjek, go;
    public float routinTime;
    private bool stat;
    enemy enemy;
  //  imune imune;
    private int score = 0;
    public GUIText textScore;
    public GUIText textGameOver;

    private List<GameObject> enemies;
    private List<float> enemySpeed;
    Material m;

    public SpriteRenderer bodyAreaView;
    public bool levelUp=false, imuneStat=false,isActiveImune=false;

    private int maxEnemy;
    public int currentTime,imuneOverTime;

	public Canvas canvas;
    //private Material spriteDefault,temp;

    // Use this for initialization
    void Start ()
    {
		//canvas.enabled = false;
		//canvas.isActiveAndEnabled = false;

        gameOver = false;
        currentTime = 0;
        routinTime=2f;
        maxEnemy=1;
        /*spriteDefault = bodyArea.material;
        bodyArea.material = new Material(Shader.Find("Diffuse"));
        temp = bodyArea.material;*/

        enemies = new List<GameObject>();
        enemySpeed = new List<float>();
        Debug.Log("inserting enemies");
        enemies.Add(Resources.Load("Low Bactery") as GameObject);
        enemySpeed.Add(0.05f);
        enemies.Add(Resources.Load("Middle Bactery") as GameObject);    
        enemySpeed.Add(0.075f);
        enemies.Add(Resources.Load("High Bactery") as GameObject);
        enemySpeed.Add(0.1f);
        Debug.Log(enemies.Count+" enemies inserted");
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTime = (int) Time.time;
        Debug.Log("gameover: " + gameOver);
        if (!gameOver)
        {
            if ((currentTime + 1) % 10 == 0)
                levelUp = true;

            if (currentTime % 10 == 0 && levelUp)
            {
                if(maxEnemy<enemies.Count)
                    maxEnemy++;
                else
                {
                    routinTime = routinTime - 0.2f;
                }
                levelUp = false;
                Debug.Log("Levelup");
            }

            if(!stat)
            {
                stat = true;
                StartCoroutine(spawnEnemy(Random.Range(0, maxEnemy), routinTime));
            }
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

    public int count=0;
    private bool gameOver;

    public bool GameOver
    {
        get
        {
            return gameOver;
        }

        set
        {
            gameOver = value;
        }
    }

    public void onDamage()
    {
        if (!isActiveImune)
        {
            bodyAreaView.color = Color.Lerp(bodyAreaView.color, Color.red, Time.deltaTime + 0.2f);
            count++;
        }
        if (count>=10)
        {
            gameOver = true;
            textGameOver.text = "GAME OVER";
        }
    }

    public void addScore(int value)
    {
        if(!gameOver)
        {
            score += value;
            updateScore();
        }
    }

    private void updateScore()
    {
        textScore.text = "Score " + score;
    }
}

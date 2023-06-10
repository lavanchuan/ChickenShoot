using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public static readonly string TAG = "Space";

    float deltaTimeDropRock = 2f;
    float speedDropRock;
    readonly float MAX_SPEED_DROP_ROCK = 1.7f;
    float timerDropRock;
    Timer gameTime;

    // scale rock
    int plus = 50;
    float scalePlus;
    float minScale = Rock.MIN_SCALE * 1000;
    float maxScale = Rock.MAX_SCALE * 1000;
    float deltaTimePlus = 5f;

    // CHICKEN
    public int chickenLevel = 1;
    readonly float deltaTimeNextChicken = 60f;
    public int sumChickenInvader = 0;
    public int[,] map = new int[0,0];
    float timerChicken;

    // BOSS
    public int bossLevel = 1;
    public bool[] callBoss = new bool[Boss.MAX_LEVEL];
    public Boss boss;

    Controller controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        gameTime = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();

        transform.localPosition = (Vector2)Camera.main.ScreenToWorldPoint(
            new Vector2(GameSetting.WIDTH/2, GameSetting.HEIGHT));

        // ROCK
        // StartCoroutine(EffectDropObject(deltaTimeDropRock));
        // CHICKEN INVADER
        // StartCoroutine(EffectChickInvaderAttack(deltaTimeNextChicken));
    }

    IEnumerator EffectDropObject(float effectTime){
        while(true){
            yield return new WaitForSeconds(effectTime);
            CreateRock();
        }
    }

    IEnumerator EffectChickInvaderAttack(float effectTime){
        while(true){
            yield return new WaitForSeconds(effectTime);
            if(sumChickenInvader <= 0){
                if(CheckCreateBoss(chickenLevel, Chicken.MAX_LEVEL, Boss.MAX_LEVEL)){
                    if(!callBoss[bossLevel-1]){
                        callBoss[bossLevel-1] = true;
                        boss = CreateBoss(bossLevel);
                        // increase boss level when boss current die
                    } else {
                        if(boss == null){
                            MapChiken(chickenLevel);
                            if(++chickenLevel >= Chicken.MAX_LEVEL){
                                chickenLevel = Chicken.MAX_LEVEL;
                            }
                        }
                    }
                } else {
                    MapChiken(chickenLevel);
                    if(++chickenLevel >= Chicken.MAX_LEVEL){
                        chickenLevel = Chicken.MAX_LEVEL;
                    }
                }
            }
        }
    }

    IEnumerator EffectBossAttack(float effectTime){
        while(true){
            yield return new WaitForSeconds(effectTime);
            
        }
    }

    void CreateRock(){
        
        scalePlus = (gameTime.totalTimePlay / deltaTimePlus) * plus;
        if(scalePlus >= maxScale - 1) scalePlus = maxScale - 1;
        float scale = UnityEngine.Random.Range(minScale, minScale + scalePlus) / 1000.0f;
        int rate = UnityEngine.Random.Range(1000, 10000) % (Rock.MAX_TYPE_ROCK) + 1;
        string nameRockPrefabs = "Rock" + (rate < 10 ? "0" + rate : "" + rate);
        GameObject rock = (GameObject)Instantiate(Resources.Load("Prefabs/Objects/" + nameRockPrefabs));
        rock.transform.localPosition = Position.GetRandomRelativePosition(transform.localPosition.y);
        rock.transform.localScale = rock.transform.localScale * scale;
    }

    GameObject CreateChicken(int level, Vector2 startPos, Vector2 endPos){
        string nameChickenPrefabs = "ChickenLevel" + (level < 10 ? "0"+level : ""+level);
        GameObject chicken = (GameObject)Instantiate(Resources.Load("Prefabs/Chicken/" + nameChickenPrefabs));
        chicken.transform.localPosition = startPos;
        chicken.GetComponent<ChickenFly>().endPos = endPos;
        chicken.GetComponent<Chicken>().health = Chicken.HEALTH_BASIC * level * (long)Math.Pow(10, 2 + level / 3);
        chicken.GetComponent<Chicken>().score = chicken.GetComponent<Chicken>().health;
        return chicken;
    }

    Boss CreateBoss(int level){
        string nameBossPrefabs = "Boss" + (level < 10 ? "0"+level : ""+level);
        // DEBUG
        Debug.Log(nameBossPrefabs);
        Boss boss = ((GameObject)Instantiate(Resources
        .Load("Prefabs/Chicken/" + nameBossPrefabs))).GetComponent<Boss>();
        boss.transform.localPosition = new Vector2(0, 10);
        boss.health = 5 * level * (long)Math.Pow(10, level+2);
        return boss;
    }

    bool CheckCreateBoss(int chickenLevel, int chickenMaxLevel, int bossMaxLevel){
        if(chickenLevel - 1 == chickenMaxLevel - 1) return true;
        for(int i = 1; i <= bossMaxLevel; i++){
            if(chickenLevel-1 == ChickenLevelForBossLevel(i, chickenMaxLevel, bossMaxLevel))
                return true;
        }
        return false;
    }

    int ChickenLevelForBossLevel(int bossLevel, int chickenMaxLevel, int bossMaxLevel){
        // if(bossLevel == 1) return chickenMaxLevel / bossMaxLevel;
        if(bossLevel <= bossMaxLevel - chickenMaxLevel % bossMaxLevel)
            return (chickenMaxLevel / bossMaxLevel) * bossLevel;
        return (chickenMaxLevel / bossMaxLevel) + 1 
            + ChickenLevelForBossLevel(bossLevel-1, chickenMaxLevel, bossMaxLevel);
    }

    void MapChiken(int chickenLevel){
        // LOAD MAP
        ChickenMap cm = new ChickenMap().MapRandom();
        map = cm.map;
        sumChickenInvader = cm.sumChickenInvader;

        // CREATE CHICKEN INVADER
        int center = map.GetLength(1)/2;
        int index = center;
        while(index < map.GetLength(1)){
            for(int i = 0; i < map.GetLength(0); i++){
                if(index == center){
                    if((int)map.GetValue(i, index) == 1){
                        CreateChicken(chickenLevel, Position.GetRandomRelativePosition(transform
                        .localPosition.y), new Vector2(index - center, map.GetLength(0)-1-i));
                    }
                } 
                else {
                    if((int)map.GetValue(i, index - 2 * (index - center)) == 1){
                        CreateChicken(chickenLevel, Position.GetRandomRelativePosition(transform
                        .localPosition.y), new Vector2(center - index, map.GetLength(0)-1-i));
                    }
                    if((int)map.GetValue(i, index) == 1){
                        CreateChicken(chickenLevel, Position.GetRandomRelativePosition(transform
                        .localPosition.y), new Vector2(index - center, map.GetLength(0)-1-i));
                    }
                }
            }
            index++;
        }
    }

    public int clr;
    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        // ROCK
        // Increase speed drop rock
        timerDropRock += Time.deltaTime;
        if(timerDropRock >= deltaTimeDropRock - speedDropRock){
            timerDropRock = 0;

            CreateRock();

            speedDropRock += 0.01f;
            if(speedDropRock >= MAX_SPEED_DROP_ROCK){
                speedDropRock = MAX_SPEED_DROP_ROCK;
            }
        }

        // Chicken
        timerChicken += Time.deltaTime;
        
        if(timerChicken >= deltaTimeNextChicken){
            timerChicken = 0;

            if(sumChickenInvader <= 0){
                
                if(bossLevel <= Boss.MAX_LEVEL - Chicken.MAX_LEVEL % Boss.MAX_LEVEL){
                    clr = bossLevel * (Chicken.MAX_LEVEL / Boss.MAX_LEVEL);
                } else {
                    clr = (Boss.MAX_LEVEL - Chicken.MAX_LEVEL % Boss.MAX_LEVEL)
                        * (Chicken.MAX_LEVEL / Boss.MAX_LEVEL)
                        + (bossLevel - (Boss.MAX_LEVEL - Chicken.MAX_LEVEL % Boss.MAX_LEVEL))
                        * (Chicken.MAX_LEVEL / Boss.MAX_LEVEL + 1);
                }

                if(chickenLevel-1 == clr || chickenLevel == Chicken.MAX_LEVEL){
                    if(!callBoss[bossLevel-1]){
                        callBoss[bossLevel-1] = true;
                        boss = CreateBoss(bossLevel);
                        // increase boss level when boss current die
                    } else {
                        if(boss == null){
                            MapChiken(chickenLevel);
                            if(++chickenLevel >= Chicken.MAX_LEVEL){
                                chickenLevel = Chicken.MAX_LEVEL;
                            }
                        }
                    }
                } else {
                    MapChiken(chickenLevel);
                    if(++chickenLevel >= Chicken.MAX_LEVEL){
                        chickenLevel = Chicken.MAX_LEVEL;
                    }
                }
            }
        }
    }

    // CHICKEN
    public int GetChickenLevelCurrent(){return this.chickenLevel;}
    public void DecreaseSumChickenInvader(){
        if(--this.sumChickenInvader < 0) this.sumChickenInvader = 0;
    }


}

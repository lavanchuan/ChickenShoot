using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float deltaTimeShoot = 0.5f;
    float speedShoot = 0f;
    readonly float MAX_SPEED_SHOOT = 0.3f;
    float deltaAngle = 10f;
    Player player;
    string nameBulletPrefabs;
    float timer;
    int bulletLevel;

    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        player = GetComponent<Player>();

        StartCoroutine(EffectShootBullet(deltaTimeShoot));
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        bulletLevel = player.GetBulletLevel();

        if(bulletLevel > 1){
            speedShoot = (bulletLevel - 1) * MAX_SPEED_SHOOT / (Bullet.BULLET_LEVEL_MAX - 1);
        }

        // timer += Time.deltaTime;
        // if(timer >= deltaTimeShoot - speedShoot){
        //     timer = 0;
        //     ShootBullet(bulletLevel);
        // }
    }

    void ShootBullet(int bulletLevel){
        nameBulletPrefabs = "BulletLevel" + (bulletLevel < 10 ? "0" + bulletLevel : ""+bulletLevel);
        for(int i = 0; i < player.GetBulletQuantity(); i++){
            GameObject bullet = (GameObject) Instantiate(Resources.Load("Prefabs/Bullets/"+nameBulletPrefabs));
            bullet.transform.rotation = Quaternion.Euler(0, 0, (i%2==1?1:-1) * (i+1)/2 * deltaAngle);
            bullet.transform.localPosition = new Vector2(transform.localPosition.x, 
                transform.localPosition.y + 0.5f);
        }  
    }

    IEnumerator EffectShootBullet(float effectTime){
        while(true){
            yield return new WaitForSeconds(effectTime - speedShoot);
            if(controller.gameState == GameDefine.GameState.PLAY)
            ShootBullet(bulletLevel);
        }
    }
}

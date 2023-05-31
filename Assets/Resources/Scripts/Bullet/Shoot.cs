using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float deltaTimeShoot = 0.5f;
    // public float timer;
    public Vector2 pos;
    private void Start() {
        StartCoroutine(EffectShootBullet(deltaTimeShoot));
    }

    private void update() {
        // timer += Time.deltaTime;
        // if(timer % 1 >= 0 || timer % 1 <= 0.01)
        //     ShootBullet();
        pos = transform.position;
    }

    void ShootBullet(){
        GameObject bullet = (GameObject) Instantiate(Resources.Load("Prefabs/Bullets/Bullet"));
        bullet.transform.localPosition = new Vector2(transform.localPosition.x, 
            transform.localPosition.y + 0.5f);
    }

    IEnumerator EffectShootBullet(float effectTime){
        while(true){
            yield return new WaitForSeconds(effectTime);
            ShootBullet();
        }
    }
}

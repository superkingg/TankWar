using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullect : MonoBehaviour
{
    private float speed = 10;
    public bool isPlayer;

    void Start()
    {
        
    }


    void Update()
    {   
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);//向物体前方运动
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞检测
    {
        switch (collision.tag)
        {
            case "Tank":
                if(!isPlayer)
                {
                    Destroy(gameObject);
                    collision.gameObject.SendMessage("Die");//调用collision游戏对象的死亡方法
                }

                break;
            case "Enemy":
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Heart":
                Destroy(gameObject);
                collision.SendMessage("Die");
                break;
            case "Barriar":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}

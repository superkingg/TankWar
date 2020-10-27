using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //定义属性
    private SpriteRenderer str;//定义一精灵渲染组件
    private Vector3 bullectEularAngles;//定义子弹旋转的角度
    private float timeBullect;//子弹cd事件
    private bool isDefended=true;//判断是否无敌
    private float DefendTime=3f;//无敌时间



    //引用
    public float speed = 1;//定义一个速度
    public Sprite[] sprites;//定义一个坦克精灵数组,上右下左
    public GameObject bulletPrefab;//子弹预制体
    public GameObject ExplosionEffectPrefab;//爆炸特效
    public GameObject DefendEffectPrefab;//无敌特效


    //public Sprite[] bulletSprites;//定义一个子弹精灵数组

    void Start()
    {
        str = GetComponent<SpriteRenderer>();//接受精灵渲染组件
    }

    void Update()
    {   if(isDefended)
        {
            DefendTime -= Time.deltaTime;//进行类减计时
            DefendEffectPrefab.SetActive(true);//显示特效
            if (DefendTime<=0)
            {
                isDefended = false;
                DefendEffectPrefab.SetActive(false);//关闭特效
            }
            
;
        }
        
        if (timeBullect>0.4f)
        {
            Attack();
        }
        else
        {
            timeBullect += Time.deltaTime;
        }
    }
    private void FixedUpdate()//生命周期函数，拥有固定帧
    {
        Move();
        

    }

    private void Attack()//攻击方法
    {
        if (Input.GetKeyDown(KeyCode.Space))//如果按下空格键
        {   
            //子弹的角度等于当前坦克的角度+子弹应该旋转的角度
            Instantiate(bulletPrefab,transform.position,Quaternion.Euler(transform.eulerAngles+bullectEularAngles));//实例化子弹预制体
            //Quaternion为四元角度转换为欧拉角度！
            timeBullect = 0;

        }
    }

    private void Move()//移动方法
    {
        int v = (int)Input.GetAxisRaw("Vertical");//接受一个垂直方向移动的值
        transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);//控制物体垂直方向移动
        if (v < 0)//如果向下移动，即h<0
        {
            str.sprite = sprites[2];
            bullectEularAngles = new Vector3(0, 0, -180);
            //bulletPrefab.GetComponent<SpriteRenderer>().sprite = bulletSprites[2];
        }
        else if (v > 0)
        {
            str.sprite = sprites[0];
            bullectEularAngles = new Vector3(0, 0, 0);
            //bulletPrefab.GetComponent<SpriteRenderer>().sprite = bulletSprites[0];
        }
        if (v != 0)
        {
            return;
        }
        int h = (int)Input.GetAxisRaw("Horizontal");//接受一个水平方向移动的值
        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);//控制物体水平方向移动
        if (h < 0)//如果向左移动，即h<0
        {
            str.sprite = sprites[3];
            bullectEularAngles = new Vector3(0, 0, 90);
            //bulletPrefab.GetComponent<SpriteRenderer>().sprite = bulletSprites[3];
        }
        else if (h > 0)
        {
            str.sprite = sprites[1];
            bullectEularAngles = new Vector3(0, 0, -90);
           // bulletPrefab.GetComponent<SpriteRenderer>().sprite = bulletSprites[1];
        }
    }

    private void Die()//死亡方法
    {
        if(isDefended)
        {
            return;
        }
        Instantiate(ExplosionEffectPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}

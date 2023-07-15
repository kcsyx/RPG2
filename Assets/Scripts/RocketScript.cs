
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private float attackPower;
    private float weaponRange;
    private Vector3 initialPosition;
    public float splashRange;

    public void Initialize(float attackPower, float weaponRange)
    {
        this.attackPower = attackPower;
        this.weaponRange = weaponRange;
        this.initialPosition = transform.localPosition;
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(AssetManager.Assets.GetPrefab("Explosion"), transform.position, transform.rotation);
        explosion.GetComponent<ExplosionScript>().Initialize(attackPower, splashRange);
        Destroy(gameObject);
    }

    void Update()
    {
        if ((transform.position - initialPosition).magnitude >= this.weaponRange)
        {
            Explode();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Explode();
        }

        if (collision.gameObject.tag == "Tilemap Colliders")
        {
            Explode();
        }

        if (collision.gameObject.tag == "Safe Area")
        {
            Destroy(gameObject);
        }
    }
}


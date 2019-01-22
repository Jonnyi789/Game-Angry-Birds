using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

    internal void OnCollisionEnter2D(Collision2D collision)
    {
        float ve = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (ve > ThresholdForce)
            Boom();
    }

    private void Destruct()
    {
        Destroy(gameObject);
    }

    private void Boom()
    {
        GetComponent<PointEffector2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);
    }
}

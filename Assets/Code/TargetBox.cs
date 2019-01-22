using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreenRight;
    public static float OffScreenLeft;

    internal void Start() {
        OffScreenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
        OffScreenLeft = Camera.main.ScreenToWorldPoint(new Vector3(100, 0, 0)).x;   // This line is newly added for boxes blasted away leftward!
    }

    internal void Update()
    {
        if ((transform.position.x > OffScreenRight) || (transform.position.x < OffScreenLeft))
            Scored();
    }

    internal void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Scored();
    }

    private void Scored()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        float mas = GetComponent<Rigidbody2D>().mass;
        if (gameObject.tag != "Scored")
        {
            ScoreKeeper.AddToScore(mas);
            gameObject.tag = "Scored";  // Make sure each box only scores once
        }
    }
}

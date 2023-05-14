using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float speed = 300.0f;
    private const float horizontalSpeed = 20.0f;

    private Vector3 direction;
    private Vector2 target;

    private Transform LBorder { get; set; }
    private Transform RBorder { get; set; }


    private Rigidbody2D Rigidbody { get; set; }
    private AudioSource Source { get; set; }
    private SpriteRenderer Render { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Source = GetComponent<AudioSource>();
        Render = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        LBorder = GameObject.Find("lBorder").transform;
        RBorder = GameObject.Find("rBorder").transform;

        Render.sprite = Resources.Load<Sprite>($"balls/{BallManager.BallId}");

        var rv = Random.Range(0, 100);
        var x = rv > 50 ? RBorder.position.x : LBorder.position.x;
        Rigidbody.position = new Vector2(x, transform.position.y);

        direction = rv > 50 ? Vector3.back : Vector3.forward;
        target = Rigidbody.position;
    }

    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime * direction);

        if(Input.GetMouseButtonDown(0))
        {
            target = new Vector2(-1 * target.x, Rigidbody.position.y);
        }

        Rigidbody.position = Vector2.MoveTowards(Rigidbody.position, target, horizontalSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(SettingsManager.VibraEnbled)
        {
            Handheld.Vibrate();
        }

        if (SettingsManager.SoundsEnabled)
        {
            if(Source.isPlaying)
            {
                Source.Stop();
            }

            Source.Play();
        }
    }
}

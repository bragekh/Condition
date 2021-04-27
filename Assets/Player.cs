using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float moveSpeed;
    public float jumpHeight;
    public float aliveTimer;
    public float extraHeight = 0.2f;
    private Rigidbody2D rb;
    float moveX, moveY;
    private Animator anim;
    private SpriteRenderer render;

    public Text timerText;
    private BoxCollider2D boxC;
    private void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxC = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();

        SaveableData.SD.data.bananasCollected = 0;
        SaveableData.SD.data.amount = 0;
    }
    public void FixedUpdate() {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (moveX != 0) {
            anim.SetBool("walk", true);
            if (moveX >= 1) {
                render.flipX = false;
            }

            if (moveX <= -1) {
                render.flipX = true;
            }
        }
        else {
            anim.SetBool("walk", false);
        }
        rb.velocity = new Vector2(moveX, rb.velocity.y);
        AliveTimer();
    }
    public void Update() {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            SoundManager.SM.PlaySound("JUMP");
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (!IsGrounded())
            anim.SetBool("inair", true);

        else
            anim.SetBool("inair", false);

    }
    public bool IsGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(boxC.bounds.center, Vector2.down, boxC.bounds.extents.y + extraHeight, LayerMask.GetMask("Ground"));
        Color raycolor;
        if (hit.collider != null)
            raycolor = Color.green;
        else
            raycolor = Color.red;
        Debug.DrawRay(boxC.bounds.center, Vector2.down * (boxC.bounds.extents.y + extraHeight), raycolor);
        return hit.collider != null;
    }
    bool timerActive = true;
    public void AliveTimer() {
        if (timerActive) {
            aliveTimer -= Time.fixedDeltaTime;
            timerText.text = aliveTimer.ToString("00");

            if (aliveTimer <= 0) {
                if (File.Exists(Application.dataPath + "/DoNotEditYouLilBitch.json")){

                    string json = File.ReadAllText(Application.dataPath + "/DoNotEditYouLilBitch.json");
                 SaveThis loaded = JsonUtility.FromJson<SaveThis>(json);
                if (loaded.bananasCollected < SaveableData.SD.data.bananasCollected)
                    SaveData.Save(SaveableData.SD.data);
                }
                else
                    SaveData.Save(SaveableData.SD.data);

                SaveableData.SD.data.amount = SaveableData.SD.data.bananasCollected;
                SceneManager.LoadScene("OutOfTime");
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Collectable>()) {
            SoundManager.SM.PlaySound("COLLECT");
            Destroy(other.gameObject);
            SaveableData.SD.CollectedBanana();
        }
    }
}

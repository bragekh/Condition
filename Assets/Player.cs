using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
    using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float moveSpeed;
    public float jumpHeight;
    public float aliveTimer;
    public int calscium;
    private Rigidbody2D rb;
    float moveX, moveY;

    public Text timerText;
    private BoxCollider2D boxC;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        boxC = GetComponent<BoxCollider2D>();
    }
    public void FixedUpdate() {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }
    public void Update() {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (calscium == 10)
            print("You Win!");
    }
    public bool IsGrounded() {
        float height = 0.01f;
        RaycastHit2D hit = Physics2D.Raycast(boxC.bounds.center, Vector2.down, boxC.bounds.extents.y + height);
        if (hit.collider != null)
            return true;
        else
            return false;

    }
    bool timerActive = true;
    public void AliveTimer(FileInfo save) {
        if (timerActive) {

            aliveTimer -= Time.fixedDeltaTime;
            timerText.text = aliveTimer.ToString("00");

            if (aliveTimer <= 0) {
                SceneManager.LoadScene("GameScene");
            }

        }

    }
    public void Load(FileInfo save) {
      
        foreach (GameObject r in GetComponent<SaveableData>().resetObjects) {
            r.transform.position = SaveData.LoadSave(save);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Collectable>()) {
            SoundManager.SM.PlaySound("COLLECT");
            Destroy(other.gameObject);
            calscium++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int characterId;
    public string characterName;
    public int maxHealth;
    public float speed;
    public string spritePath;

    public bool hasInit;

    public Rigidbody2D rb;
    public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hasInit = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void SetPlayerData(Character characterData)
    {

        this.characterId = characterData.characterId;
        this.characterName = characterData.characterName;
        this.maxHealth = characterData.maxHealth;
        this.speed = characterData.speed;
        this.spritePath = characterData.spritePath;

        SpriteRenderer characterSprite = gameObject.GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load<Sprite>(this.spritePath);
        characterSprite.sprite = sprite;

        hasInit = true;
        transform.GetChild(0).gameObject.SetActive(true);
        anim.SetTrigger(characterName);
    }

    public void LookAtMouse()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector3)(mousePos - new Vector2(transform.position.x, transform.position.y));

        transform.GetChild(0).gameObject.transform.right = this.transform.up.normalized;
    }

    public void MovePlayer()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = input.normalized * speed;

        if(rb.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }
    }
}

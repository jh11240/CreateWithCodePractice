using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem DeathEffect;
    public ParticleSystem DirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;
    //public AnimationClip animationClip;
    public Animator animator;
    private Vector3 startPos;
    
    public bool FastMode=false;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public int isJumping = 0;
    public bool gameOver = false;
    public bool gameStart = false;
    private Vector3 defaultGravity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        //animationClip = GetComponent<Animator>().runtimeAnimatorController.animationClips[0];
        Physics.gravity *= gravityModifier;
        defaultGravity = Physics.gravity;
        startPos = transform.position;

        //startAnimation
        StartCoroutine(StartWalking());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) &&isJumping<2 && !gameOver )
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
          
            playerAnim.SetTrigger("Jump_trig");
            DirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);

            //더 빨리 떨어지기 위해
            Physics.gravity *= 2f;
            isJumping++;
        }
        //jump가 아닐때만 두배로
        if ( isJumping<1&& Input.GetKey(KeyCode.B))
        {
            FastMode = true;
            animator.speed = 2f;
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            FastMode = false;
            animator.speed= 1f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //중력을 제자리로
            Physics.gravity = defaultGravity;
            DirtParticle.Play();
            isJumping=0;
        }
        else if (!gameOver && collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            DeathEffect.Play();
            DirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    private IEnumerator StartWalking()
    {
        DirtParticle.Stop();
        animator.SetFloat("Speed_f", 0.3f);
        yield return new WaitForSeconds(1f);
        while(Vector3.Distance(transform.position, (startPos+ Vector3.right * 14)) > .5f)
        {
            //일단 걷기.
            transform.position = Vector3.Lerp(transform.position, startPos + Vector3.right * 14, Time.deltaTime * 0.8f);
            yield return null;
        }

        //그리고 뛰기
        StartCoroutine(StartRunning());
    }
    private IEnumerator StartRunning()
    {
        animator.SetFloat("Speed_f", 1f);
        DirtParticle.Play();
        while (Vector3.Distance(transform.position, startPos) > .5f)
        {
            //뛰자~.
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
            yield return null;
        }
        gameStart = true;
        yield break;
    }
    
}

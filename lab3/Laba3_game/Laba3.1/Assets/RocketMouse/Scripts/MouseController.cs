using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class MouseController : MonoBehaviour 
{
    [SerializeField] private Text coinsLabel;
    [SerializeField] private GameObject restartDialog;
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
    public Transform groundCheckTransform;
    public LayerMask groundCheckLayerMask;
    public ParticleSystem jetpack;
    public Texture2D coinIconTexture;
    public AudioClip coinCollectSound;
    public AudioSource jetpackAudio;
    public AudioSource footstepsAudio;
    public ParallaxScroll parallax;

    private Animator animator;
    private bool grounded;
    private bool dead = false;
    private uint coins = 0;
    private Rigidbody2D rb;
    void Start () 
    {
        restartDialog.SetActive(false);
        animator = GetComponent<Animator>();	
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () 
    {
        coinsLabel.text = coins.ToString();
        bool jetpackActive = Input.GetButton("Fire1");
	    jetpackActive = jetpackActive && !dead;
	    if (jetpackActive) 
	    { 
	        rb.AddForce(new Vector2(0, jetpackForce));
	    }
	    if (!dead) 
	    {
	        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
	        newVelocity.x = forwardMovementSpeed;
	        rb.velocity = newVelocity;
	    }
  	    UpdateGroundedStatus();
	    AdjustJetpack(jetpackActive);
	    AdjustFootstepsAndJetpackSound(jetpackActive);
	    parallax.offset = transform.position.x;
    } 

    void UpdateGroundedStatus() 
    {
        grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
        animator.SetBool("grounded", grounded);
    }

    void AdjustJetpack (bool jetpackActive) 
    {
  	    ParticleSystem.EmissionModule jpEmission = jetpack.emission;
	    jpEmission.enabled = !grounded;
	    jpEmission.rateOverTime = jetpackActive ? 300.0f : 75.0f; 
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Coins")) 
        {
	        CollectCoin(collider);
        } 
        else 
        {
            HitByLaser(collider);
	    } 
    }

    void HitByLaser(Collider2D laserCollider) 
    {
        if (!dead) 
        {
            laserCollider.gameObject.GetComponent<AudioSource>().Play();
	    }
	    dead = true;
	    animator.SetBool("dead", true);
        restartDialog.SetActive(true);
    }

    void CollectCoin(Collider2D coinCollider) 
    {
        coins++;
        Destroy(coinCollider.gameObject);
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    

  void AdjustFootstepsAndJetpackSound(bool jetpackActive) 
  {
      footstepsAudio.enabled = !dead && grounded;
      jetpackAudio.enabled =  !dead && !grounded;
	  jetpackAudio.volume = jetpackActive ? 1.0f : 0.5f;        
  }
}

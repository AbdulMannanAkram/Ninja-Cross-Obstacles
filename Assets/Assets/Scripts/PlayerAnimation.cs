using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timeElapsed = 0.0f;
    public Sprite[] idleFrames;
    public Sprite[] runFrames;
    public Sprite[] jumpFrames;
    public Sprite[] deathFrames;
    public float frameDuration = 0.1f;
    public string currentAnimation = "Idle";

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (currentAnimation)
        {
            case "Idle":
                AnimateIdle();
                break;
            case "Run":
                AnimateRun();
                break;
            case "Jump":
                AnimateJump();
                break;
            case "Death":
                AnimateDeath();
                break;
            default:
                AnimateIdle();
                break;
        }
    }

    private void AnimateIdle()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > frameDuration)
        {
            currentFrame = (currentFrame + 1) % idleFrames.Length;
            spriteRenderer.sprite = idleFrames[currentFrame];
            timeElapsed = 0.0f;
        }
    }

    private void AnimateRun()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > frameDuration)
        {
            currentFrame = (currentFrame + 1) % runFrames.Length;
            spriteRenderer.sprite = runFrames[currentFrame];
            timeElapsed = 0.0f;
        }
    }

    private void AnimateJump()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > frameDuration)
        {
            currentFrame = (currentFrame + 1) % jumpFrames.Length;
            spriteRenderer.sprite = jumpFrames[currentFrame];
            timeElapsed = 0.0f;
        }
    }

    private void AnimateDeath()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > frameDuration)
        {
            currentFrame = (currentFrame + 1) % deathFrames.Length;
            spriteRenderer.sprite = deathFrames[currentFrame];
            timeElapsed = 0.0f;
        }
    }

    public void PlayIdleAnimation()
    {
        currentAnimation = "Idle";
    }

    public void PlayRunAnimation()
    {
        currentAnimation = "Run";
    }

    public void PlayJumpAnimation()
    {
        currentAnimation = "Jump";
    }

    public void PlayDeathAnimation()
    {
        currentAnimation = "Death";
    }
}

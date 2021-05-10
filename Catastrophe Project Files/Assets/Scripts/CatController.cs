using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    [SerializeField] float waitRandomFactor = 1f;

    [Header("Animations General")]
    [SerializeField] float animationSpeed;
    [SerializeField] float animationSpeedMin = 0.5f;
    [SerializeField] float animationSpeedMax = 3f;

    [Header("Twitch Animations")]
    [SerializeField] List<AnimationClip> twitchAnimations = new List<AnimationClip>();
    [SerializeField] float twitchWaitTimeMin = 5f;
    [SerializeField] float twitchWaitTimeMax = 8f;
    [SerializeField] int blinkProbability = 30;

    [Header("Special Animations")]
    [SerializeField] List<AnimationClip> specialAnimations = new List<AnimationClip>();
    [SerializeField] int clickCount = 0;
    [SerializeField] int maxClicks = 10;
    [SerializeField] int minIntervalClicks = 8;
    [SerializeField] int specialAnimationProbability = 30;


    Animator animator;
    VaseController vase;

    private void Start()
    {
        animator = GetComponent<Animator>();
        vase = FindObjectOfType<VaseController>();

        StartCoroutine(WaitBeforeTwitchAnimation());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vase.TurnOn();

            clickCount++;
            if(clickCount > maxClicks)
            {
                PlaySpecialAnimation();
            }
            else
            {
                StartCoroutine(ReachForVase());
            }
        }
    }

    public IEnumerator ReachForVase()
    {
        var waitTimeReach = GetWaitTimeReach();
        animationSpeed = GetAnimationSpeed(true);

        yield return new WaitForSeconds(waitTimeReach);

        animator.speed = animationSpeed;
        animator.SetBool("isReaching", true);
        animator.SetBool("isKnockingOver", false);

        StartCoroutine(KnockVaseOver(waitTimeReach));
    }

    private float GetWaitTimeReach()
    {
        var waitRandomness = Random.Range(-waitRandomFactor, waitRandomFactor);
        float waitTimeReach;

        int probability = Random.Range(0, 101);
        if (probability < 40)
        {
            waitTimeReach = 0f;
        }
        else if (probability < 60)
        {
            waitTimeReach = 0.5f;
        }
        else if (probability < 80)
        {
            waitTimeReach = 1f;
        }
        else
        {
            waitTimeReach = 2f;
        }
        waitTimeReach += waitRandomness;
        return waitTimeReach;
    }

    private IEnumerator KnockVaseOver(float waitTimeReach)
    {
        var waitTimeKnock = Random.Range(0, waitTimeReach);
        animationSpeed = GetAnimationSpeed(false);

        yield return new WaitForSeconds(waitTimeKnock);

        animator.speed = animationSpeed;
        animator.SetBool("isKnockingOver", true);
        animator.SetBool("isReaching", false);
    }

    private float GetAnimationSpeed(bool reachOrKnock)
    {
        float animationSpeedMinTemp;
        if (reachOrKnock)
        {
            animationSpeedMinTemp = animationSpeedMin;
        }
        else
        {
            animationSpeedMinTemp = animationSpeed;
        }
        animationSpeed = Random.Range(animationSpeedMinTemp, animationSpeedMax);
        return animationSpeed;
    }

    private IEnumerator WaitBeforeTwitchAnimation()
    {
        yield return new WaitForSeconds(Random.Range(twitchWaitTimeMin, twitchWaitTimeMax));

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            PlayTwitchAnimations();
        }
        StartCoroutine(WaitBeforeTwitchAnimation());
    }

    private void PlayTwitchAnimations()
    {
        if(!animator.GetBool("isReaching"))
        {
            int animationIndex;
            var probability = Random.Range(0, 101);
            if (probability < blinkProbability)
            {
                animationIndex = 0;
            }
            else
            {
                animationIndex = Random.Range(1, twitchAnimations.Count);
            }
            GetComponent<Animator>().Play(twitchAnimations[animationIndex].name);
        }
    }

    private void PlaySpecialAnimation()
    {
        var probability = Random.Range(0, 101);
        if(probability < specialAnimationProbability)
        {
            GetComponent<Animator>().Play(specialAnimations[Random.Range(0, specialAnimations.Count)].name);
            clickCount = maxClicks - minIntervalClicks;
        }
        else
        {
            StartCoroutine(ReachForVase());
        }
    }
}

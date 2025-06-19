using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    [SerializeField] private AudioClip footstepClip;
    private AudioSource footstepAudioSource;
    [SerializeField] private Transform player;
    [SerializeField] private float maxVolumeDistance = 5f;
    [SerializeField] private float minVolume = 0.1f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        footstepAudioSource = gameObject.AddComponent<AudioSource>();
        footstepAudioSource.clip = footstepClip;
        footstepAudioSource.loop = true;
        footstepAudioSource.playOnAwake = false;
    }
    void Update()
    {
        float speed = agent.velocity.magnitude;

        if (speed > 0.1f)
        {
            if (!footstepAudioSource.isPlaying)
                footstepAudioSource.Play();

            if (player == null)
            {
                GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
                if (foundPlayer != null)
                    player = foundPlayer.transform;
            }

            if (player != null)
            {
                float distance = Vector3.Distance(transform.position, player.position);
                float volumeFactor = Mathf.Clamp01(1 - (distance / maxVolumeDistance));
                footstepAudioSource.volume = Mathf.Lerp(minVolume, 1f, volumeFactor);
            }
        }
        else
        {
            if (footstepAudioSource.isPlaying)
                footstepAudioSource.Stop();
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{


    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip finishSound;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    AudioSource mainAudio;
    bool isTransitioning = false;

    private void Start()
    {
        mainAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning){return;}
        switch (collision.gameObject.tag)
        {
            case "Finish":
               StartNextLevelSequence();
                break;
            case "Friendly":
                Debug.Log("Hit a Friendly Object");
                break;
            default:
               StartCrashSequence();
                break;
        }
    }
    void StartNextLevelSequence()
    {
        // TODO add sfx when next level (Done)
        // TODO add particle fx when next level (Done)

      
            isTransitioning = true;
            mainAudio.Stop();     
            mainAudio.PlayOneShot(finishSound);
            finishParticles.Play();
            GetComponent<Movement>().enabled = false;
            Invoke(nameof(LoadNextLevel), delay);
       
        
    }
    void StartCrashSequence()
    {
        // TODO add sfx when next level (Done)
        // TODO add particle fx when next level (Done)

        isTransitioning = true;
            mainAudio.Stop();
            mainAudio.PlayOneShot(crashSound);
            crashParticles.Play(finishSound);
            GetComponent<Movement>().enabled = false;
            Invoke(nameof(ReloadLevel), delay);

        

    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);

    }
}

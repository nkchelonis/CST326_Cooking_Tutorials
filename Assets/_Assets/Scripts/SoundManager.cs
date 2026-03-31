using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    
    
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
    }

    private void CuttingCounter_OnAnyCut(object sender, EventArgs eventArgs)
    {
        CuttingCounter counter = sender as CuttingCounter;
        PlaySound(audioClipRefsSO.chop, counter.transform.position);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliveryFail, deliveryCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliverySuccess, deliveryCounter.transform.position);
    }


    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        
        PlaySound(audioClipArray[Random.Range(0,audioClipArray.Length)], position, volume);
    }
}

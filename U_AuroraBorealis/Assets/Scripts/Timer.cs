using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace FabriciohodDev
{
    [Serializable]
    public class Timer
    {
        [SerializeField] public float durationInSecs;
        [Space] public UnityEvent<float> OnTimerTick;
        [Space] public UnityEvent OnTimerEnded;
        
        public void StartTimer(Action callBackOnEnd = default)
        {
            C_StartTimer(callBackOnEnd, durationInSecs);
        }

        private async void C_StartTimer(Action callbackOnEnd, float durationInSecs)
        {
            float passedTime = 0f;

            while (passedTime < durationInSecs)
            {
                passedTime += Time.deltaTime;
                OnTimerTick?.Invoke(passedTime / durationInSecs);

                await Task.Yield();
            }

            callbackOnEnd.Invoke();
            OnTimerEnded?.Invoke();
        }
    }
}

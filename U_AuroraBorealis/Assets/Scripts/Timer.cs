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

        public void StartTimer(Action callBackOnEnd = default)
        {
            C_StartTimer(callBackOnEnd, durationInSecs);
        }

        private async void C_StartTimer(Action callback, float duration)
        {
            float passedTime = 0f;

            while (passedTime < duration)
            {
                passedTime += Time.deltaTime;
                OnTimerTick?.Invoke(passedTime / duration);

                await Task.Yield();
            }

            callback.Invoke();
        }
    }
}

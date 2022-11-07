using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace ActionSystem
{
    public delegate void SubscriberFunction(GameObject mParam = null);

    //public delegate void SubscriberFunctionParam();

    public enum EEventType
    {
        eRestartGameEvent,
        eAttackBegin,
        eAttackEnd,
        eItemCollected,
        eAttachPointTriggered,
        eItemTaken,
        ePlayerHandMovingBack,
        eLevelComplete,
        eChangeActivePage
    }

    public class CEvents
    {
        public void Register(EEventType mEventType, SubscriberFunction mSubscriberFunction)
        {
            FunctionList(mEventType).Add(mSubscriberFunction);
            Debug.Log("Registrated");
        }

        /*public void RegisterParam(EEventType mEventType, SubscriberFunctionParam mSubscriberFunctionParam)
        {

        }*/

        public void Unregister(EEventType mEventType, SubscriberFunction mSubscriberFunction)
        {
            FunctionList(mEventType).Remove(mSubscriberFunction);
        }

        public void Invoke(EEventType mEventType)
        {
            foreach (SubscriberFunction mSubscriberFunction in FunctionList(mEventType))
            {
                mSubscriberFunction.Invoke();
            }
        }

        public void Invoke(EEventType mEventType, GameObject mParam)
        {
            foreach (SubscriberFunction mSubscriberFunction in FunctionList(mEventType))
            {
                mSubscriberFunction.Invoke(mParam);
            }
        }

        protected Dictionary<EEventType, List<SubscriberFunction>> mDictionary = new Dictionary<EEventType, List<SubscriberFunction>>();

        protected List<SubscriberFunction> FunctionList(EEventType mEventType)
        {

            if (mDictionary.ContainsKey(mEventType) == false)
            {
                mDictionary[mEventType] = new List<SubscriberFunction>();
            }

            return mDictionary[mEventType];
        }
    }
}



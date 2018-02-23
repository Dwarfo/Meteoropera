using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDestruction : MonoBehaviour {

    public virtual void OnDestruction(OnDeathEventArgs e)
    {
        EventHandler<OnDeathEventArgs> handler = meteorDestroyed;
        if (handler != null)
        {
            handler(this, e);
        }
    }

        public event EventHandler<OnDeathEventArgs> meteorDestroyed;
    }

    public class OnDeathEventArgs : EventArgs
    {
        public OnDeathEventArgs()
        {

        }   
    }

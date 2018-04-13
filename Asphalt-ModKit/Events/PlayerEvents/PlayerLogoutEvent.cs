﻿using Eco.Gameplay.Players;
using System;

namespace Asphalt.Api.Event.PlayerEvents
{
    /// <summary>
    ///  Called when the user logs out
    /// </summary>
    public class PlayerLogoutEvent : IEvent
    {
        public User User { get; protected set; }  //protected because we can't change it

        public PlayerLogoutEvent(User pUser) : base()
        {
            this.User = pUser;
        }
    }

    internal class PlayerLogoutEventHelper
    {
        public void Logout()
        {
            PlayerLogoutEvent cEvent = new PlayerLogoutEvent((User)((object)this));
            IEvent iEvent = cEvent;

            EventManager.CallEvent(ref iEvent);

            Logout_original();
        }

        public void Logout_original()
        {
            throw new InvalidOperationException();
        }
    }
}

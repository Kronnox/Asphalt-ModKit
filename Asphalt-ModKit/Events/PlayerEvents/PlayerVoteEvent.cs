﻿using Asphalt.Events;
using Eco.Core.Utils.AtomicAction;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;

namespace Asphalt.Api.Event.PlayerEvents
{
    public class PlayerVoteEvent : CancellableEvent
    {
        public User User { get; set; }

        public PlayerVoteEvent(User pUser) : base()
        {
            this.User = pUser;
        }
    }

    internal class PlayerVoteEventHelper
    {
        public static bool Prefix(User user, ref IAtomicAction __result)
        {
            PlayerVoteEvent cEvent = new PlayerVoteEvent(user);
            IEvent iEvent = cEvent;

            EventManager.CallEvent(ref iEvent);

            if (cEvent.IsCancelled())
            {
                __result = new FailedAtomicAction(new LocString());
                return false;
            }

            return true;
        }
    }
}

﻿using Asphalt.Events;
using Eco.Core.Utils.AtomicAction;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Services;
using System;

namespace Asphalt.Api.Event.PlayerEvents
{
    /// <summary>
    /// Called when a player sends a chat message
    /// </summary>
    public class PlayerSendMessageEvent : CancellableEvent
    {
        public User User { get; set; }

        public ChatMessage Message { get; set; }

        public PlayerSendMessageEvent(User user, ChatMessage message) : base()
        {
            this.User = user;
            this.Message = message;
        }
    }

    internal class PlayerSendMessageEventHelper
    {
        public IAtomicAction CreateAtomicAction(User user, ChatMessage message)
        {
            PlayerSendMessageEvent psme = new PlayerSendMessageEvent(user, message);
            IEvent psmeEvent = psme;

            EventManager.CallEvent(ref psmeEvent);

            if (!psme.IsCancelled())
                return CreateAtomicAction_original(psme.User, psme.Message);

            return new FailedAtomicAction(new LocString());
        }

        public IAtomicAction CreateAtomicAction_original(User user, ChatMessage message)
        {
            throw new InvalidOperationException();
        }
    }
}

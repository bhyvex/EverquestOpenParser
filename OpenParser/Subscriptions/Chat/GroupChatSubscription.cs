﻿using System.Text.RegularExpressions;
using OpenParser.EventResults.Chat;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Chat
{
    public class GroupChatSubscription : Subscription<ChatMessage>
    {
        public GroupChatSubscription(LogFile logFile)
        {
            Subscriber = new Subscriber<ChatMessage>(logFile,
                new RegexStrategy<ChatMessage>(Constants.Chat.GroupRegex, HandleMatches));
            Subscribe();
        }

        private ChatMessage HandleMatches(LogEntry entry, Match match)
        {
            var from = match.Groups[1].Value;
            var message = match.Groups[6].Value;

            return new ChatMessage(entry, from, message);
        }
    }
}
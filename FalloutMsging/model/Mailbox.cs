using System;
using System.Collections.Generic;

namespace FalloutMsging.model
{
	/**
        This class represents a collection of objects of type Message. This Mailbox
	    has two basic types it can be: TYPE_INBOX and TYPE_OUTBOX.

	    @see Message
	    @author Paul Walter
     */
	public class Mailbox
    {
		public static readonly int TYPE_INBOX = 0;
		public static readonly int TYPE_OUTBOX = 1;
		private int type = TYPE_INBOX;
		private List<Message> messages;

		/**
			Constructor.
			@param type needs to be either TYPE_INBOX, or TYPE_OUTBOX.
		*/
		public Mailbox(int type)
		{
			messages = new List<Message>();
		}

		/**
			Add a message to the mailbox's list of messages.
			@param msg This is the Message we wish to add to our collection.
		*/
		public void addMsg(Message msg)
		{
			messages.Add(msg);
		}

		/**
			Get a list of all messages availible.
			@return A list of all the messages.
		*/
		public List<Message> getMsgs()
		{
			return messages;
		}

		/**
			Get the type of this Mailbox: either TYPE_INBOX, or TYPE_OUTBOX.
			@return This mailbox's type.
		*/

		public int getType()
		{
			return type;
		}
	}
}

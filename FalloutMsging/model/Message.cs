using System;
namespace FalloutMsging.model
{
    public class Message
	{
		private User sender;
		private User recipient;
		private String text;
		private DateTime date;

		/**
			Constructor. 
			@param sender The User who has sent this message
			@param recipient The User who is recieving this message
			@param text The text that the user is conveying.
			@param date The date this message was athored on. 
		*/
		public Message(User sender, User recipient, String text, DateTime date)
		{
			this.sender = sender;
			this.recipient = recipient;
			this.text = text;
			this.date = date;
		}

		/**
			Return's who sent this message.
			@return Which User sent this message.
		*/
		public User getsender()
		{
			return sender;
		}

		/**
			Return who is recieving this message.
			@return The User who is reciving this message.
		*/
		public User getRecipient()
		{
			return recipient;
		}

		/**
			The text of this Message
			@return The text of this message.
		*/
		public String getText()
		{
			return text;
		}
	}
}

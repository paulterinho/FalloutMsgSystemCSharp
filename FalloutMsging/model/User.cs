using System;
using System.Collections.Generic;

namespace FalloutMsging.model
{
    /**
		User is a person in this message system that can have 2 or more
		Mailboxes.
		
		@see Mailbox
		@author Paul Walter
	*/
    public class User
    {
        private String username;
        private String password;
        private List<Mailbox> mailboxes;

        /**
            Constructor
            @param username The name of the user to be used in the system
            @param password The password the user will use to access the system
            @param mailboxes The List of Mailboxes that this User should have.	 	
        */
        public User(String username, String password, List<Mailbox> mailboxes)
        {
            this.username = username;
            this.password = password;
            this.mailboxes = mailboxes;
        }

        /**
            Constructor: will automatically create a Inbox and Outbox
            @param username The name of the user to be used in the system
            @param password The password the user will use to access the system
        */

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }


        /**
            This method will return verify that a username/password
            combination match the one in this class. 
            
            @return True if the username and password match, else it returns a false.
        */
        public bool verify(String un, String pw)
        {
            if (this.username.Equals(un))
            {
                if (this.password.Equals(pw))
                {
                    return true;
                }
            }
            return false;
        }

        /**
            This method will return one of the user's mailboxes
            @param type This will either take a Mailbox.TYPE_INBOX or Mailbox.TYPE_OUTBOX
        */
        public Mailbox getMailbox(int type)
        {
            foreach (Mailbox mb in mailboxes)
            {
                if (mb.getType() == type)
                {
                    return mb;
                }
            }
            return null;
        }

        /**
         * @throws MessageSystemException
         */
        public void recieveMail(Message msg)
        {
            //find inbox
            bool mailboxWasFound = false;

            foreach (Mailbox mb in mailboxes)
            {
                if (mb.getType() == Mailbox.TYPE_INBOX)
                {
                    mb.addMsg(msg);
                    mailboxWasFound = true;
                    return;
                }
            }

            throw new MessageSystemException("Inbox not found for user: " + username);


        }

        /**
			This returns this user's username.
		*/
        public String getUsername()
        {
            return username;
        }
    }
}

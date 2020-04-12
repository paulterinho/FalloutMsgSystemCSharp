using System;
using System.Collections.Generic;
using FalloutMsging.model;
namespace FalloutMsging
{
    public class Program
    {
        private static readonly int STATE_LOGIN = 0;
        private static readonly int STATE_LIST = 1;
        private static readonly int STATE_CREATE = 2;
        private static readonly int STATE_READ = 3;
        private int state = STATE_LOGIN;
        private User currentUser;
        private Mailbox currentMailbox;
        private Message currentMessage;
        private List<User> listOfUsers;

        /**
			Constructor. 
		*/
        public Program()
        {
            reset();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program();
        }

        /**
			Reset, will clear out the internal variables and set
			the state back to STATE_LOGIN. 
		*/
        private void reset()
        {
            currentMailbox = null;
            currentMessage = null;
            currentUser = null;
            state = STATE_LOGIN;
        }

        /**
			This is a method that will find a user in our collection of users.
			@username The username of the User we are trying to find. 
		*/
        private User findUser(String username)
        {
            foreach (User u in listOfUsers)
            {
                if (u.getUsername().Equals(username))
                {
                    return u;
                }
            }
            return null;
        }

        /**
			This will return the current state of this class.
		*/
        public int getState()
        {
            return state;
        }

        private void setState(int i)
        {
            state = i;
        }

        /**
			This allows the current user to login and get a 
			list of messages in the TYPE_INBOX.

            @throws MessageSystemException
		*/
        public List<Message> login(String username, String password)
        {
            //make sure we are in login state
            if (getState() != STATE_LOGIN)
            {
                throw new MessageSystemException("You are already logged in");
            }

            // find user
          
            User foundUser = findUser(username);
            if (foundUser != null)
            {
                // verify password
                if (foundUser.verify(username, password))
                {
                    //we found the user, now get it's inbox
                    currentMailbox = foundUser.getMailbox(Mailbox.TYPE_INBOX);
                    if (currentMailbox != null)
                    {
                        return currentMailbox.getMsgs();
                    }
                }
                else
                {
                    throw new MessageSystemException("Wrong login credentials.");
                }
            }

            // 
            return null;
        }

        /**
            Blocks access to the system. 
        */
        public void logout()
        {
            reset();
        }
    }
}

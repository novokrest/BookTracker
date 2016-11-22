using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookTracker.Models
{
    public enum Book
    {
        ProAspNetMvcPlatform,
        PatterntOfEnterpriseApplication,
        AndroidForProfessional
    }

    public class Votes
    {
        private readonly static IDictionary<Book, int> _votes = new Dictionary<Book, int>();

        public static int GetVotes(Book book)
        {
            return _votes.ContainsKey(book) ? _votes[book] : 0;
        }

        public static void RegisterVote(Book book)
        {
            _votes[book] = _votes.ContainsKey(book) ? ++_votes[book] : 1;
        }

        public static void ChangeVote(Book oldBook, Book newBook)
        {
            if (_votes.ContainsKey(oldBook))
            {
                --_votes[oldBook];
            }
            RegisterVote(newBook);
        }
    }
}
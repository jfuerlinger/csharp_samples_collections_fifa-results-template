using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FifaResults.Entities.Contracts;

namespace FifaResults.Entities
{
    public class Club : IMarkdownProvider
    {
        #region Fields

        private readonly IList<Player> _players;
        private readonly string _name;
        private readonly string _logo;

        #endregion

        #region Properties

        public string Name => _name;
        public string Logo => _logo;
        public IEnumerable<Player> Players => _players;

        public double AverageAge
        {
            get
            {
                throw new NotImplementedException();

            }
        }

        public double AverageWage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long OverallValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Constructors

        public Club(string name, string logo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        public void AddPlayer(Player player)
        {
            throw new NotImplementedException();
        }


        public string GetMarkdown()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

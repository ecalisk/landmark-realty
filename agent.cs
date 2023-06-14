using System;
using System.Collections.Generic;
using System.Text;

namespace landmark_realty
{
    class agent : owner 
    {
        public agent (string fullName, string birthDay, string address, string phoneNumber, string emailAddress, string agentID)
            : base(fullName, birthDay, address, phoneNumber, emailAddress) { this.agentID = agentID; }

        public string agentID { get; set; }
    }
}

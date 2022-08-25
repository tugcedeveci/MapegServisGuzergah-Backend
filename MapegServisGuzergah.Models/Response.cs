using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models
{
    public class Response<T>
    {
        public List<T> ModelList { get; set; }

        public T Model { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message code.
        /// </summary>
        /// <value>
        /// The message code.
        /// </value>
        public int MessageCode { get; set; }

        /// <summary>
        /// Gets or sets the message title.
        /// </summary>
        /// <value>
        /// The message title.
        /// </value>
        public string MessageTitle { get; set; }

        /// <summary>
        /// Gets or sets the message detail.
        /// </summary>
        /// <value>
        /// The message detail.
        /// </value>
        public string MessageDetail { get; set; }
    }
}

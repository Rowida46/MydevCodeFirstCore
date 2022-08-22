using System;

namespace MydevcCodeFirstCore.Models
{
    public class Articles
    {
        /*
         id = db.Column(db.Integer, primary_key = True)
	    auther = db.Column(db.String(120))
	    title = db.Column(db.String(120), nullable = False)
	    body = db.Column(db.String(400), nullable = False)
	    time_stamp = get_timestamp()
         */

        public int id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime time_stamp { get; set; }


    }
}
